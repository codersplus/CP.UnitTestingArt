using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
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
