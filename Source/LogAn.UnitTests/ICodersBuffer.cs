using System.Collections.Generic;

namespace LogAnTests
{
    public interface ICodersBuffer<T>
    {
        void Write(T input);
        Queue<T> Read();
    }
}