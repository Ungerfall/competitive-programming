<Query Kind="Program" />

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

public class Program
{
	public static async Task Main(string[] args)
	{
		string configFile = args[0];
		configFile = Path.Combine(Directory.GetCurrentDirectory(), configFile);
		string config = File.ReadAllText(configFile);
		var cfg = JsonSerializer.Deserialize<Configuration>(config);
		var loadBalancer = new LoadBalancer(cfg);
		int i = 0;
		string key = null;
		while ((key = Console.ReadLine()) != null)
		{
			Console.Error.WriteLine($"loop {i++}");
			var (client, isMainDb) = loadBalancer.GetStorageClient(key);
			string value = null;
			if (isMainDb)
			{
				var response = await client.GetAsync(key);
				value = await response.Content.ReadAsStringAsync();
				await loadBalancer.Replicate(key, value);
			}
			else
			{
				var response = await client.GetAsync(key);
				if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
				{
					loadBalancer.MarkCorrupted(key);
					client = loadBalancer.GetStorageClient(key).Item1;
					response = await client.GetAsync(key);
					value = await response.Content.ReadAsStringAsync();
					Console.WriteLine(value);
				}
				else
				{
					value = await response.Content.ReadAsStringAsync();
					Console.WriteLine(value);
				}
			}

			Console.WriteLine(value);
			Console.Error.WriteLine($"{key} {client.BaseAddress} {isMainDb}");
		}
	}
}

public class LoadBalancer
{
	public LoadBalancer(Configuration cfg)
	{
		dbClient = new HttpClient() { BaseAddress = new Uri(cfg.DbUrl) };
		numberOfReplicas = cfg.CacheUrls.Length;
		for (int i = 0; i < cfg.CacheUrls.Length; i++)
		{
			caches[i] = new HttpClient { BaseAddress = new Uri(cfg.CacheUrls[i]) };
		}
	}

	private readonly int numberOfReplicas;
	private readonly HttpClient dbClient;
	private readonly Dictionary<int, HttpClient> caches = new Dictionary<int, HttpClient>();
	private readonly HashSet<string> takenFromDb = new HashSet<string>();
	private HashSet<int> corrupted = new HashSet<int>();

	public (HttpClient, bool) GetStorageClient(string key)
	{
		if (!takenFromDb.Contains(key))
		{
			takenFromDb.Add(key);
			return (dbClient, true);
		}
		else
		{
			var id = GetCacheId(key, numberOfReplicas);
			if (corrupted.Contains(id))
			{
				return (dbClient, false);
			}

			return (caches[id], false);
		}
	}

	public async Task Replicate(string key, string value)
	{
		var id = GetCacheId(key, numberOfReplicas);
		var client = caches[id];
		await client.PutAsync(key, new StringContent(value));
	}

	public void MarkCorrupted(string key)
	{
		var id = GetCacheId(key, numberOfReplicas);
		corrupted.Add(id);
	}

	public static int GetCacheId(string key, int numberOfReplicas)
	{
		using (MD5 md5 = MD5.Create())
		{
			byte[] inputBytes = Encoding.UTF8.GetBytes(key);
			byte[] hashBytes = md5.ComputeHash(inputBytes);

			// Convert hash bytes to an integer
			// (could use a longer hash size if needed)
			int hashValue = BitConverter.ToInt32(hashBytes, 0);

			return Math.Abs(hashValue) % numberOfReplicas;
		}
	}
}

public class Configuration
{
	[JsonPropertyName("db_url")]
	public string DbUrl { get; set; }

	[JsonPropertyName("cache_urls")]
	public string[] CacheUrls { get; set; }
}

void Main()
{

}
