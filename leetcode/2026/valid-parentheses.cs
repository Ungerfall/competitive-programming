#!/usr/bin/env dotnet run

Solution s = new();
bool result = s.IsValid("()[]{}");
Console.WriteLine(result);

public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> seen = [];
        seen.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            char pair = s[i] switch
            {
                ']' => '[',
                ')' => '(',
                '}' => '{',
                _ => '!'
            };

            if (pair == '!')
            {
                seen.Push(s[i]);
            }
            else
            {
                if (!seen.TryPop(out char opening) || opening != pair)
                {
                    return false;
                }
            }

        }

        return seen.Count == 0;
    }
}
