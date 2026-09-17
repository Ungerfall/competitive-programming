#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
string ransomNote = "aa";
string magazine = "aab";
var result = s.CanConstruct(ransomNote, magazine);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (ransomNote.Length > magazine.Length)
        {
            return false;
        }

        const int size = 26;
        int[] counter = new int[size];
        for (int i = 0; i < magazine.Length; i++)
        {
            int index = magazine[i] - 'a';
            counter[index]++;
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            int index = ransomNote[i] - 'a';
            counter[index]--;
        }

        for (int i = 0; i < size; i++)
        {
            if (counter[i] < 0)
            {
                return false;
            }
        }

        return true;
    }
}
