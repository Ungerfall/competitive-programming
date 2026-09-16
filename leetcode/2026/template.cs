#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
var result = s.TODO(...);
string print = result.ToString();
Console.WriteLine(print);
