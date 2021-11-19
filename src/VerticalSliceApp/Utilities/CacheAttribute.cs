namespace VerticalSliceApp.Utilities;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CacheAttribute : Attribute
{
    public int AbsoluteExpirationRelativeToNowInSeconds { get; set; }

    public int SlidingExpirationInSeconds { get; set; }
}