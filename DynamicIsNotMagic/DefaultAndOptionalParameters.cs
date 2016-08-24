using System;
using NUnit.Framework;

namespace DynamicIsNotMagic
{
    [TestFixture]
    public class DefaultAndOptionalParameters
    {
        public void SomeMethodWithDefaultParameters(string message=null)
        {
            Console.WriteLine(message??"Default messsage here");
        }

        public void SomeMethodWithOptionalParameters(string m1, string m2=null, string m3=null)
        {
            Console.WriteLine(m1??"M1 is null");
            Console.WriteLine(m2??"M2 is null");
            Console.WriteLine(m3??"M3 is null");
            Console.WriteLine();
        }

        [Test]
        public void CanUseDefaultParameters()
        {
            var dynamicObject = this as dynamic;
            dynamicObject.SomeMethodWithDefaultParameters("Custom message here");
            dynamicObject.SomeMethodWithDefaultParameters();
            Console.WriteLine();
        }

        [Test]
        public void CanUseOptionlParameters()
        {
            var dynamicObject = this as dynamic;
            dynamicObject.SomeMethodWithOptionalParameters("some string",m3:"other string");
            dynamicObject.SomeMethodWithOptionalParameters("some text");
            dynamicObject.SomeMethodWithOptionalParameters();
        }
    }
}