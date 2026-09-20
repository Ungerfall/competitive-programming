#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;
using System.Numerics;
using System.Globalization;

Solution s = new();
string a = "0";// "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101";
string b = "0";//"110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011";
var result = s.AddBinary(a, b);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public string AddBinary(string a, string b)
    {
        BigInteger aAsInt = BigInteger.Parse("0" + a, NumberStyles.AllowBinarySpecifier);
        BigInteger bAsInt = BigInteger.Parse("0" + b, NumberStyles.AllowBinarySpecifier);

        BigInteger result = aAsInt + bAsInt;

        Console.WriteLine((aAsInt, bAsInt, result));

        string trimmed = result.ToString("B").TrimStart('0');
        return trimmed.Length == 0 ? "0" : trimmed;
    }
}
