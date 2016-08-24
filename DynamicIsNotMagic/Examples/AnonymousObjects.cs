using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DynamicIsNotMagic.Examples
{
    [TestFixture]
    public class AnonymousObjects
    {
        [Test]
        public void Example()
        {
            var users = GetItems();
            var count = users.Count(x => x.Name.StartsWith("А") && x.Gender == "Ж");
            Assert.AreEqual(2, count);
        }

        public IEnumerable<dynamic> GetItems()
        {
            return new[]
            {
                new {Id = 1, Name = "Александр", Gender = "М"},
                new {Id = 2, Name = "Анна", Gender = "Ж"},
                new {Id = 3, Name = "Анастасия", Gender = "Ж"},
                new {Id = 4, Name = "Игнат", Gender = "М"},
                new {Id = 5, Name = "Виктория", Gender = "Ж"},
            };
        }
    }
}
