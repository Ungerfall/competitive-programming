<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.WordBreak("leetcode", System.Text.Json.JsonSerializer.Deserialize<List<string>>("[\"leet\",\"code\"]")).Dump();
	s.WordBreak("applepenapple", System.Text.Json.JsonSerializer.Deserialize<List<string>>("""["apple","pen"]""")).Dump();
	s.WordBreak("catsandog", System.Text.Json.JsonSerializer.Deserialize<List<string>>("""["cats","dog","sand","and","cat"]""")).Dump();
}

public class Solution
{
	public bool WordBreak(string s, IList<string> wordDict)
	{
		var trie = new Trie();
		foreach (var word in wordDict)
		{
			trie.Insert(word);
		}
		
		return trie.Search(s);
	}
	
	class TrieNode
	{
		const int SIZE = 26;
		public bool End{get;set;}
		public TrieNode[] Children{get;set;} = new TrieNode[SIZE];
	}
	class Trie
	{
		private readonly TrieNode _root = new TrieNode();
		
		public TrieNode Insert(string word)
		{
			TrieNode crawl = _root;
			for (int i = 0; i < word.Length; i++)
			{
				int code = word[i] - 'a';
				if (crawl.Children[code] == null)
				{
					crawl.Children[code] = new TrieNode();
				}
				
				crawl = crawl.Children[code];
			}
			
			crawl.End = true;
			return crawl;
		}
		
		public bool Search(string candidate)
		{
			bool[] canFormFromIndex = new bool[candidate.Length];
			return SearchCompositeCandidate(_root, candidate, start: 0, isWordFound: false, canFormFromIndex);
		}
		
		public bool SearchCompositeCandidate(TrieNode node, string candidate, int start, bool isWordFound, bool[] canFormFromIndexMemo)
		{
			if (start == candidate.Length)
			{
				return isWordFound;
			}
			
			if (canFormFromIndexMemo[start])
			{
				return false;
			}
			
			TrieNode crawl = node;
			for (int i = start; i < candidate.Length; i++)
			{
				int code = candidate[i] - 'a';
				if (crawl.Children[code] == null)
				{
					canFormFromIndexMemo[start] = true;
					return false;
				}
				
				crawl = crawl.Children[code];
				if (crawl.End)
				{
					if (SearchCompositeCandidate(_root, candidate, i + 1, isWordFound: true, canFormFromIndexMemo))
					{
						return true;
					}
				}
			}
			
			canFormFromIndexMemo[start] = true;
			return false;
		}
	}
}
