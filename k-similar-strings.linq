<Query Kind="Program">
  <Namespace>System.Collections.Specialized</Namespace>
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

void Main()
{
	var s = new Solution();
	/*
	s.KSimilarity("ab", "ba").Dump();
	s.KSimilarity("abc", "bca").Dump();
	s.KSimilarity("abac", "baca").Dump();
	s.KSimilarity("aabc", "abca").Dump();
	s.KSimilarity("abccaacceecdeea", "bcaacceeccdeaae").Dump();
	*/
	s.KSimilarity("abccab", "abccab").Dump();
}

public class Solution
{
	public int KSimilarity(string s1, string s2)
	{
		if (s1.Equals(s2))
			return 0;
			
		var q = new UniqueQueue();
		var visited = new HashSet<string>();
		visited.Add(s1);
		q.Enqueue(s1);
		int len = 0;
		while (q.Count > 0)
		{
			len++;
			int end = q.Count;
			for (int qi = 0; qi < end; qi++)
			{
				var s = q.Dequeue();
				int i = 0;
				while (i < s.Length && s[i] == s2[i])
					i++;

				for (int j = i + 1; j < s.Length; j++)
				{
					if (s[j] == s2[j] || s[j] != s2[i])
						continue;

					var @new = Swap(s, i, j);
					if (@new.Equals(s2))
						return len;
						
					if (visited.Add(@new))
					{
						q.Enqueue(@new);
					}
				}
			}
		}

		return len;
	}

	public class UniqueQueue
	{
		private HashSet<string> hashSet;
		private Queue<string> queue;


		public UniqueQueue()
		{
			hashSet = new HashSet<string>();
			queue = new Queue<string>();
		}


		public int Count
		{
			get
			{
				return hashSet.Count;
			}
		}

		public bool Contains(string item)
		{
			return hashSet.Contains(item);
		}


		public void Enqueue(string s)
		{
			if (hashSet.Add(s))
			{
				queue.Enqueue(s);
			}
		}

		public string Dequeue()
		{
			var s = queue.Dequeue();
			hashSet.Remove(s);
			return s;
		}
	}

	public static string Swap(string a, int i, int j)
	{
		char temp;
		char[] charArray = a.ToCharArray();
		temp = charArray[i];
		charArray[i] = charArray[j];
		charArray[j] = temp;
		string s = new string(charArray);
		return s;
	}
}