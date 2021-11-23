using Microsoft.EntityFrameworkCore;

namespace Npgsql6
{
    public sealed class TestDbContext : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; } = null!;

        public TestDbContext()
            : base(
                new DbContextOptionsBuilder<TestDbContext>()
                    .UseNpgsql("Server=localhost;Port=5432;Database=testNpgsql6;User Id=postgres;Password=password", o => o.UseNodaTime())
                    .Options
            )
        { }
    }
}
