using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public interface ISetting
    {
        string ScreenName();
    }

    public class Settings : ISetting
    {

        public static readonly Settings Instacnce = new Settings();

        private Settings()
        {
            
        }

        public string ScreenName()
        {
            return "Domino's Central";
        }
    }

}
