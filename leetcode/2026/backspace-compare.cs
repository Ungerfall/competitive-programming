#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
string ss = "j##yc##bs#srqpfzantto###########i#mwb";
string tt = "j##yc##bs#srqpf#zantto###########i#mwb";
var result = s.BackspaceCompare(ss, tt);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public bool BackspaceCompare(string s, string t)
    {
        //Console.WriteLine(s);
        //Console.WriteLine(t);
        int sPointer = s.Length - 1;
        int tPointer = t.Length - 1;
        int sBackspaces = 0;
        int tBackspaces = 0;
        while (sPointer >= 0 && tPointer >= 0)
        {
            do
            {
                if (s[sPointer] == '#')
                {
                    sBackspaces++;
                    sPointer--;
                }
                else if (sBackspaces > 0)
                {
                    sBackspaces--;
                    sPointer--;
                }
                else
                {
                    break;
                }
            } while (sPointer >= 0);

            do
            {
                if (t[tPointer] == '#')
                {
                    tBackspaces++;
                    tPointer--;
                }
                else if (tBackspaces > 0)
                {
                    tBackspaces--;
                    tPointer--;
                }
                else
                {
                    break;
                }
            } while (tPointer >= 0);

            //Console.WriteLine((sPointer, tPointer));
            if (tPointer == -1 && sPointer == -1)
            {
                return true;
            }

            if (tPointer == -1 || sPointer == -1)
            {
                break;
            }

            char sChar = s[sPointer];
            char tChar = t[tPointer];
            //Console.WriteLine((sPointer, tPointer, sChar, tChar));
            if (tChar != sChar)
            {
                return false;
            }

            sPointer--;
            tPointer--;
        }

        if (tPointer == -1 || sPointer == -1)
        {
            bool tOrS = !(tPointer == -1);
            int remainingPointer = tOrS ? tPointer : sPointer;
            int remainingBackspaces = tOrS ? tBackspaces : sBackspaces;
            //Console.WriteLine((tPointer, sPointer, remainingPointer, remainingBackspaces, (tOrS ? t : s)[..remainingPointer]));
            for (; remainingPointer >= 0; remainingPointer--)
            {
                char current = tOrS ? t[remainingPointer] : s[remainingPointer];
                if (current == '#')
                {
                    remainingBackspaces++;
                }
                else
                {
                    if (remainingBackspaces == 0)
                    {
                        return false;
                    }

                    remainingBackspaces--;
                }
            }

            //Console.WriteLine((tPointer, sPointer, remainingBackspaces, remainingPointer));
            return remainingBackspaces >= 0;
        }

        return true;
    }
}
