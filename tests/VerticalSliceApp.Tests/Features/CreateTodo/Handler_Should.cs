using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VerticalSliceApp.Data;
using VerticalSliceApp.Features.CreateTodo;
using Xunit;

namespace VerticalSliceApp.Tests.Features.CreateTodo;

public class Handler_Should : IDisposable
{
    private readonly Database _database;
    private readonly Handler _target;

    public Handler_Should()
    {
        var builder = new DbContextOptionsBuilder<Database>();
        builder.UseInMemoryDatabase("Todos");
        var options = builder.Options;
        _database = new Database(options);
        _target = new Handler(_database);
    }

    [Fact]
    public async Task Create_Todo_When_Command_Is_Valid()
    {
        const string expectedTitle = "whatever";
        // Arrange
        var command = new Command { Title = expectedTitle };

        // Act
        var response = await _target.Handle(command, CancellationToken.None);

        // Assert
        var actual = await _database.Todos.SingleOrDefaultAsync(t => t.Title == expectedTitle);
        Assert.NotNull(actual);
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}
