using System.Collections.Generic;
using System.Linq;

namespace DynamicIsNotMagic.Examples
{
    public class ExamStack<T>
    {
        private readonly List<T> _data = new List<T>();
        public void Push(T item) => _data.Add(item);
        public T Pop()
        {
            var item = _data.Last();
            _data.Remove(item);
            return item;
        }
    }
}
