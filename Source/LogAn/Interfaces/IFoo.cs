using System;

namespace LogAn.Interfaces
{
    public interface IFoo
    {
        string Bar();
    }

    public class Foo : IFoo
    {
        public string Bar()
        {
            throw new NotImplementedException();
        }
    }

}
