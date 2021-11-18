namespace VerticalSliceApp.Features.MarkAsDone;

public class Response
{
    public bool IsSucceded { get; set; }

    public static Response Succeded()
        => new Response { IsSucceded = true };
}