using NUnit.Framework;

namespace DynamicIsNotMagic
{
    [TestFixture]
    public class Example_ExtendObjects
    {
        public void ExtendJsonObject()
        {
            
        }

        public Data ProcessRequest() => new Data { Id = 1, Name = "Bob" };

        public class Data
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
