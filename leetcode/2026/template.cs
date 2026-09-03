#!/usr/bin/env dotnet run

using System.Text.Json.Serialization;

Solution s = new();
var result = s.TODO(...);
string print = result switch
{
    [] => "[]",
    [..] => string.Join(',', result),
    _ => result.ToString()
};

[JsonSerializable(typeof(int[]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;
