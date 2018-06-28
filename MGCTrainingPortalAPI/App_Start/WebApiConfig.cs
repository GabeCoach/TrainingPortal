using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MGCTrainingPortalAPI
{
    public static class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("https://www.mgctrainingportal.com,http://localhost:4200,https://www.mgctrainingportal.com,https://dev.coresystems.io:8855", "*", "*"));
            //config.MessageHandlers.Add(new PreflightRequestHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
