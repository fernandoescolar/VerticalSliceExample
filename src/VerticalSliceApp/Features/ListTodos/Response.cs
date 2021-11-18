namespace VerticalSliceApp.Features.ListTodos;

public class Response : Collection<ResponseItem>
{
}

public class ResponseItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
}