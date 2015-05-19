using WhiteValley.Helpers;


namespace WhiteValley.AppInsights
{
    public static class AppInsightsSettingsHelper
    {

        public static string AppInsightsIKey
        {
            get { return AppSettingsHelper.GetString("AppInsights_iKey"); }
        }


        public static string AppInsightsTags
        {
            get { return AppSettingsHelper.GetString("AppInsights_Tags"); }
        }

    }
}