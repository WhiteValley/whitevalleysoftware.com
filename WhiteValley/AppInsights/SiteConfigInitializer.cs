using System;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;


namespace WhiteValley.AppInsights
{
    
    /// <summary>
    /// Used to configure Application Insights
    /// </summary>
    public class SiteConfigInitializer : IContextInitializer
    {

        public void Initialize(TelemetryContext context)
        {
            // includes the app version with all telemetary data
            context.Component.Version = typeof(MvcApplication).Assembly.GetName().Version.ToString();

            // if tags are defined in the app settings then include them in the telemetary
            if (!String.IsNullOrEmpty(AppInsightsSettingsHelper.AppInsightsTags))
                context.Properties["tags"] = AppInsightsSettingsHelper.AppInsightsTags;
        }
    }
}