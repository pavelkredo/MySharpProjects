using System.Web.Http;
using ClientDbTelegramBot.Models;
using System.Data.Entity;
using ClientDbTelegramBot.App_Start;
using System.Web.Routing;
using System.Web.Mvc;

namespace ClientDbTelegramBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new ClientDbInitializer());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bot.GetBotClientAsync().Wait();
        }
    }
}
