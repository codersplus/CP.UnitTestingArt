
namespace LogAn.Classes
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
