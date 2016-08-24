using System;

namespace DynamicIsNotMagic
{
    public class BasicExamplesUsingDynamic
    {
        public void Dynamic()
        {
            int a = 100;
            dynamic b = a;
            b.“акогоћетодаЌе—уществует();
            a.“акогоћетодаЌе—уществует();
            b[100500] = a;
            a = b.Ќе—уществующее—войство.—Ќесуществующимћетодом().»„ем”годно;
        }

        public void Add()
        {
            dynamic a = 100;
            int b = 10;
            var c = a + b;
        }

        public int ReturnCast()
        {
            dynamic result = "10";
            return result;
        }

        public void CallName(dynamic arg)
        {
            var name = arg.Name;
        }

        public void WriteDynamic()
        {
            dynamic str = "Here string!";
            Console.WriteLine(str);
        }

        public void MoreThanOneDynamic()
        {
            dynamic str = "10";
            var value = Int16.Parse(str);
            Console.WriteLine(value);
        }

        public void DiscardResults()
        {
            dynamic str = "10";
            Int16.Parse(str);
        }
    }
}