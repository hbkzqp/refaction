using System.Web.Http;
using refactor_me.App_Start;

namespace refactor_me
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DIConfig.GetInstance().ConfigServices();

        }
    }
}
