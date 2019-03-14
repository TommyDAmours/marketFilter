using System.Web.Http;

namespace NexApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "NexAppAPI",
                routeTemplate: "stock/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
