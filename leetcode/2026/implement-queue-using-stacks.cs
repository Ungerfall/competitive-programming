#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

MyQueue q = new();
q.Push(10);
int popped = q.Pop();
int peeked = q.Peek();
bool tryEmpty = q.Empty();
Console.WriteLine((popped, peeked, tryEmpty));

public class MyQueue {

    private readonly Stack<int> _queued = [];
    private readonly Stack<int> _dequeued = [];

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        _queued.Push(x);
    }
    
    public int Pop() {
        if (_dequeued.Count > 0)
        {
            return _dequeued.Pop();
        }

        while (_queued.Count > 0)
        {
            _dequeued.Push(_queued.Pop());
        }

        return _dequeued.Pop();
    }
    
    public int Peek() {
        if (_dequeued.Count > 0)
        {
            return _dequeued.Peek();
        }

        while (_queued.Count > 0)
        {
            _dequeued.Push(_queued.Pop());
        }

        return _dequeued.Peek();
        
    }
    
    public bool Empty() {
        return _queued.Count == 0 && _dequeued.Count == 0;
    }
}
