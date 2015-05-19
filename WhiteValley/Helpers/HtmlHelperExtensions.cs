using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;



public static class HtmlHelperExtensions
{

    private static readonly UrlHelper UrlHelper = new UrlHelper();

   
        

    public static HtmlString Style(this HtmlHelper helper, string path)
    {
        return new HtmlString(BuildStyleElement(UrlHelper.Style(path)));
    }


    public static HtmlString StyleWithVersion(this HtmlHelper helper, string path)
    {
        return new HtmlString(BuildStyleElement(UrlHelper.StyleWithVersion(path)));
    }


    private static string BuildStyleElement(string fullPath)
    {
        return String.Format("<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\" />", fullPath);
    }


    public static HtmlString InlineStyle(this HtmlHelper helper, string path)
    {
        var tag = new StringBuilder();
        tag.AppendLine("<style type=\"text/css\">");
        tag.AppendLine(File.ReadAllText(helper.ViewContext.HttpContext.Server.MapPath(UrlHelper.Style(path))));
        tag.AppendLine("</style>");
        return new HtmlString(tag.ToString());
    }


    public static HtmlString InlineScriptFile(this HtmlHelper helper, string path)
    {
        var tag = new StringBuilder();
        tag.AppendLine("<script type=\"text/javascript\">");
        tag.AppendLine(File.ReadAllText(helper.ViewContext.HttpContext.Server.MapPath(UrlHelper.Script(path))));
        tag.AppendLine("</script>");
        return new HtmlString(tag.ToString());
    }



}
