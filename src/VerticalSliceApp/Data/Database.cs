namespace VerticalSliceApp.Data;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Todo> Todos { get; set; }
}
