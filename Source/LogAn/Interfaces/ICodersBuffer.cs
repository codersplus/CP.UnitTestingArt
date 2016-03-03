using System.Collections.Generic;

namespace LogAn.Interfaces
{
    public interface ICodersBuffer<T>
    {
        void Write(T input);
        Queue<T> Read();
    }
}