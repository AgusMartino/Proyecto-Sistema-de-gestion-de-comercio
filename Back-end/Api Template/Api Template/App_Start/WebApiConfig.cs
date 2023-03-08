using System.Web.Http;
using System.Web.Http.Cors;

namespace Api_Template
{
    public static class WebApiConfig
    {
        //NUEVO RUTEO POR NOMBRE
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            //Configuración de Cors (acceso desde otros dominios)
            EnableCors(config);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            //RUTEO VIEJO
            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
            );
        }
        private static void EnableCors(HttpConfiguration config)
        {
            //Para todos los dominios
            var corsAttr = new EnableCorsAttribute("*", "*", "*");

            //Para localhost
            //var corsAttr = new EnableCorsAttribute("localhost", "*", "*");

            config.EnableCors(corsAttr);
        }
    }
}
