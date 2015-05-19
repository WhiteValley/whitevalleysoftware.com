using System;


namespace WhiteValley.Helpers
{
    public static class AppSettingsHelper
    {

        public static string GetString(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key] ?? String.Empty;
        }


        public static string GetStringOrDefault(string key, string defaultValue)
        {
            var value = GetString(key);
            return String.IsNullOrEmpty(value) ? defaultValue : value;
        }


        public static string AppVersion
        {
            get { return typeof (MvcApplication).Assembly.GetName().Version.ToString(); }
        }

 
    }
}