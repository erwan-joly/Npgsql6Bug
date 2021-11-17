using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InMemoryEf5
{
    public sealed class TestDbContext : DbContext
    {

        public DbSet<TestEntity> TestEntities { get; set; } = null!;

        public TestDbContext()
            : base(
                new DbContextOptionsBuilder<TestDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options
            )
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var baseEntities = modelBuilder.Model.GetEntityTypes()
                .Where(e => !e.IsOwned() && !e.HasSharedClrType);
            foreach (var entity in baseEntities)
            {
                var entityBuilder = modelBuilder.Entity(entity.ClrType);
            }

            modelBuilder
                .Entity<TestEntity>()
                .Ignore(e => e.Values);
        }
    }
}
