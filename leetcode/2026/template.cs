#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution solution = new();
var result = solution.TODO(...);
string print = result.ToString();
Console.WriteLine(print);
