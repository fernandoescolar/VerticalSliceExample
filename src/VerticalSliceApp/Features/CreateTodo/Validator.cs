namespace VerticalSliceApp.Features.CreateTodo;

public class Validator
{
    public string? Error { get; private set; }

    public bool Validate(Command command)
    {
        if (string.IsNullOrWhiteSpace(command.Title ?? string.Empty))
        {
            Error = "Title is required";
            return false;
        }

        return true;
    }
}
