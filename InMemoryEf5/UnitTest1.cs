using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InMemoryEf5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbContext = new TestDbContext();
            dbContext.TestEntities.AddRange(new TestEntity()
            {
                Id = 1
            });
            dbContext.SaveChanges();
        }
    }
}