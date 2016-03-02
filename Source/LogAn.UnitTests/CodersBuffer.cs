using System.Collections.Generic;

namespace LogAnTests
{
    public class CodersBuffer<T> : ICodersBuffer<T>
    {
        private readonly Queue<T> _buffer;

        public CodersBuffer(int capacity = 5)
        {
            Capacity = capacity;
            _buffer = new Queue<T>();
        }

        public int Capacity { get; set; }

        public void Write(T input)
        {
            _buffer.Enqueue(input);

            if (_buffer.Count > Capacity)
            {
                _buffer.Dequeue();
            }
        }

        public Queue<T> Read()
        {
            return _buffer;
        }
    }
}