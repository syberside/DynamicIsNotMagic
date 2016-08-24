using System;
using System.Linq;
using NUnit.Framework;

namespace DynamicIsNotMagic
{
    [TestFixture]
    public class DynamicVsReflection
    {
        public class Data
        {
            public string Word { get; set; }
            public string DateToString(DateTime? date=null) => date?.ToString()??"null";
        }

        public void ByDynamic(dynamic data)
        {
            Console.WriteLine(data.Word);
            data.Word = "bla bla";
            Console.WriteLine(data.Word);
            //var @delegate = data.Now;
            Console.WriteLine(data.DateToString(DateTime.Now));
            Console.WriteLine(data.DateToString());
        }

        public void ByReflection(object data)
        {
            var prop = data.GetType().GetProperties().First(x => x.Name == "Word");
            Console.WriteLine(prop.GetValue(data));
            prop.SetValue(data, "bla bla");
            Console.WriteLine(prop.GetValue(data));
            var @delegate = data.GetType().GetMethod("DateToString");
            Console.WriteLine(@delegate.Invoke(data,new object[] {DateTime.Now}));
            Console.WriteLine(@delegate.Invoke(data, new object[0]));
        }

        [Test]
        public void Run()
        {
            ByDynamic(new Data {Word = "HI!"});
            ByReflection(new Data { Word = "HI!" });
        }
    }
}
