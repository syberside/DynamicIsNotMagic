using System;
using NUnit.Framework;

namespace DynamicIsNotMagic
{
    [TestFixture]
    public class MethodParameters
    {
        [Test]
        public void CanUseWhereNonDynamicExpected()
        {
            dynamic a = "some";
            var b = "string";
            var concat = Concat(a, b);
            Console.WriteLine(concat);
        }

        public string Concat(string a, string b)
        {
            return $"{a} {b}";
        }
    }
}