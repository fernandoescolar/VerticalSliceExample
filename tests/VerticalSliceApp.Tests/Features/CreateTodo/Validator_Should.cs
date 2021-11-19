using VerticalSliceApp.Features.CreateTodo;
using Xunit;

namespace VerticalSliceApp.Tests.Features.CreateTodo;
public class Validator_Should
{
    [Fact]
    public void ReturnValidWhenCommandIsValid()
    {
        const string expectedTitle = "whatever";
        // Arrange
        var command = new Command { Title = expectedTitle };

        // Act
        var validator = new Validator();
        var result = validator.Validate(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ReturnErrorWhenTitleIsEmpty()
    {
        // Arrange
        var command = new Command { Title = "" };

        // Act
        var validator = new Validator();
        var result = validator.Validate(command);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("Title", result.Errors[0].PropertyName);
        Assert.Equal("'Title' must not be empty.", result.Errors[0].ErrorMessage);
    }
}
