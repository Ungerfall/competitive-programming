using System;

ReadOnlySpan<char> s = "12345".AsSpan();

int ix = s.LastIndexOf('3') + 1;

Console.WriteLine(s[^1]);

