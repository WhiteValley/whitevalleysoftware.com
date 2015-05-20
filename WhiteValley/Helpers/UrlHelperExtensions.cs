using System;
using System.Web.Mvc;
using WhiteValley.Helpers;


public static class UrlHelperExtensions
{

    public static string Style(this UrlHelper helper, string path)
    {
        return String.Format("/styles/{0}", path);
    }


    public static string StyleWithVersion(this UrlHelper helper, string path)
    {
        return Style(helper, path + "?v=" + AppSettingsHelper.AppVersion);
    }


    public static string Image(this UrlHelper helper, string path)
    {
        return String.Format("/images/{0}", path);
    }


    public static string Script(this UrlHelper helper, string path)
    {
        return String.Format("/scripts/{0}", path);
    }


    public static string ScriptWithVersion(this UrlHelper helper, string path)
    {
        return Script(helper, path + "?v=" + AppSettingsHelper.AppVersion);
    }

}
