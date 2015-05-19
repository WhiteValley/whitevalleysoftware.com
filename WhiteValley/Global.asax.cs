using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WhiteValley.AppInsights;


namespace WhiteValley
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // if an application insights iKey is defined in the app settings then configure app insights
            if (!String.IsNullOrEmpty(AppInsightsSettingsHelper.AppInsightsIKey))
            {
                Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey = AppInsightsSettingsHelper.AppInsightsIKey;
                Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.ContextInitializers.Add(new SiteConfigInitializer());
            }

        }
    }
}