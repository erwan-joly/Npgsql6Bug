using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InMemoryPoc
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
                //Test method InMemoryPoc.UnitTest1.TestMethod1 threw exception:
                //System.InvalidOperationException: The entity type 'Dictionary<string, string>' requires a primary key to be defined.If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'.For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.
            }

            modelBuilder
                .Entity<TestEntity>()
                .Ignore(e => e.Values);
        }
    }
}
