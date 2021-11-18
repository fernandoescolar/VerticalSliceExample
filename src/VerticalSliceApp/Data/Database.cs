namespace VerticalSliceApp.Data;

public class Database : Hashtable
{
    private int _counter = 0;

    public int Counter => _counter;

    public int CreateId()
    {
        return ++_counter;
    }
}
