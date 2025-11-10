public class MinStack
{
    private const int GrowthFactor = 2;

    private long[] _data = [];
    private int _index = 0;
    private int _size = 0;

    public MinStack()
    {
    }

    public void Push(int val)
    {
        Grow();

        var min = val;

        if (_index > 0)
        {
            var top = _data[_index - 1];
            var topMin = (int)(top & uint.MaxValue);

            if (topMin < min)
            {
                min = topMin;
            }
        }

        long b = val;
        b <<= 32;
        b |= (uint)min;
        _data[_index++] = b;
    }

    public void Pop()
    {
        _index--;
    }

    public int Top()
    {
        return (int)(_data[_index - 1] >> 32);
    }

    public int GetMin()
    {
        return (int)(_data[_index - 1] & uint.MaxValue);
    }

    private void Grow()
    {
        if (_size > _index + 1)
        {
            return;
        }

        if (_size == 0)
        {
            _size = GrowthFactor;
        }

        var newData = new long[_size * GrowthFactor];
        Array.Copy(_data, newData, _data.Length);
        _data = newData;
        _size = _data.Length;
    }
}