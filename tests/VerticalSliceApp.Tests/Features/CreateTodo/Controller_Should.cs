using Moq;
using FluentResults;
using MediatR;
using VerticalSliceApp.Features.CreateTodo;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Controller = VerticalSliceApp.Features.CreateTodo.Controller;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

public class Controller_Should
{
    private readonly Mock<IMediator> _mediator;
    private readonly Controller _target;

    public Controller_Should()
    {
        _mediator = new Mock<IMediator>();
        _target = new Controller(_mediator.Object);

        var mockHttpContext = new Mock<HttpContext>();
        var controllerContext = new ControllerContext(new ActionContext(mockHttpContext.Object, new RouteData(), new ControllerActionDescriptor()));
        _target.ControllerContext = controllerContext;
    }

    [Fact]
    public async Task Return429WhenOperationIsNotSucceded()
    {
        // Arrange
        var command = new Command
        {
            Title = "any title"
        };

        _mediator.Setup(x => x.Send(It.IsAny<Command>(), default(System.Threading.CancellationToken)))
                 .ReturnsAsync(Result.Fail("any error"));

        // Act
        var response = await _target.EnpointAsync(command) as ObjectResult;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(429, response.StatusCode);
    }

    [Fact]
    public async Task Return200WhenOperationIsSucceded()
    {
        // Arrange
        var command = new Command
        {
            Title = "any title"
        };

        _mediator.Setup(x => x.Send(It.IsAny<Command>(), default(System.Threading.CancellationToken)))
                 .ReturnsAsync(Result.Ok());

        // Act
        var response = await _target.EnpointAsync(command) as StatusCodeResult;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(201, response.StatusCode);
    }
}
