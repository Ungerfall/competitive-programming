#!/usr/bin/env dotnet run

Solution s = new();
var result = s.TODO(...);
string print = result switch
{
    [] => "[]",
    [..] => string.Join(',', result),
    _ => result.ToString()
};

