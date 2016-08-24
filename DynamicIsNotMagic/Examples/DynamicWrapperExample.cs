using System;
using System.Dynamic;
using System.Reflection;
using NUnit.Framework;

namespace DynamicIsNotMagic.Examples
{
    public class DynamicWrapper<T> : DynamicObject
    {
        private readonly T _wrapped;

        public DynamicWrapper(T wrapped)
        {
            _wrapped = wrapped;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var member = _wrapped.GetType().GetField(binder.Name, 
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (member == null)
            {
                result = null;
                return false;
            }
            Console.WriteLine($"{binder.Name} accessed at: {DateTime.Now}");
            result = member.GetValue(_wrapped);
            return true;
        }
    }

    [TestFixture]
    public class DynamicWrapperTest
    {
        public string A = "A";
        public string B = "b";

        [Test]
        public void Test()
        {
            dynamic wrapper = new DynamicWrapper<DynamicWrapperTest>(this);
            Console.WriteLine(wrapper.A.ToLower() + wrapper.b.ToUpper());
        }
    }
}
