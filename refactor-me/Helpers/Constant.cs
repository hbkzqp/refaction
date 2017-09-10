using System.Configuration;


namespace refactor_me.Helpers
{
    public class Constant
    {
        public static readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;
    }
}