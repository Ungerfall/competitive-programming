<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2,3};
	int left = 0;
	int right = 0;
	
 	NumArray obj = new NumArray(nums);
	int param_1 = obj.SumRange(left, right);
}
public class NumArray
{
	private readonly int[] _nums;
	private int[] _runningTotals;

	public NumArray(int[] nums)
	{
		_nums = nums;
	}

	public int SumRange(int left, int right)
	{
		if (_runningTotals == null)
		{
			_runningTotals = new int[_nums.Length];
			_runningTotals[0] = _nums[0];
			for (int i = 1; i < _nums.Length; i++)
			{
				_runningTotals[i] = _runningTotals[i - 1] + _nums[i];
			}
		}

		return left == 0
			? _runningTotals[right]
			: _runningTotals[right] - _runningTotals[left - 1];
	}
}