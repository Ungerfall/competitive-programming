<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

void Main()
{
	//var arr = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[47,50],[33,41],[39,45],[33,42],[25,32],[26,35],[19,25],[3,8],[8,13],[18,27]]");
	var arr = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[10,20],[15,25],[20,30]]");
	var c = new MyCalendar();
	foreach (var element in arr)
	{
		(element[0], element[1], c.Book(element[0], element[1])).ToString().Dump();
	}
}

public class MyCalendar
{
	private SortedList<Interval, bool> bookings = new SortedList<MyCalendar.Interval, bool>(new IntervalComparer());

	public MyCalendar()
	{

	}

	public bool Book(int start, int end)
	{
		var interval = new Interval(start, end);
		if (bookings.ContainsKey(interval))
			return false;

		bookings.Add(interval, true);
		return true;
	}

	internal readonly struct Interval
	{
		public Interval(int a, int b)
		{
			A = a;
			B = b;
		}

		public int A { get; }
		public int B { get; }
	}

	internal class IntervalComparer : IComparer<Interval>
	{
		public int Compare(Interval x, Interval y)
		{
			if (y.A < x.B && y.B > x.A)
				return 0;

			return x.A.CompareTo(y.A);
		}
	}
}

/*
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */