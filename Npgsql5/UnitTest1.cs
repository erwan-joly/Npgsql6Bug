using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace Npgsql5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            await using var ctx = new TestDbContext();
            await ctx.Database.EnsureCreatedAsync();

            var conn = ctx.Database.GetDbConnection();
            await conn.OpenAsync();
            var property = ctx.Model.GetEntityTypes().First().GetTableMappings().SelectMany(p => p.ColumnMappings)
                .Skip(1).First();

            await conn.CloseAsync();

            await ctx.Database.EnsureDeletedAsync();

            Assert.AreEqual(
                $"{property.TableMapping.Table.Name} {property.Column.Name} {property.Column.PropertyMappings.First().TypeMapping.StoreTypeNameBase}",
                "TestEntities CreatedOn timestamp");
        }
    }
}