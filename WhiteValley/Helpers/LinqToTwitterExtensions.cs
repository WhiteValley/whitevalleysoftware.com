using System;
using System.Linq;
using System.Web.Mvc;
using LinqToTwitter;
using System.Web;


    
public static class LinqToTwitterExtensions
{

    /// <summary>
    /// Examines the plain text tweet for any hashtags or links and returns them as html with link elements 
    /// </summary>
    public static MvcHtmlString ToHtml(this Status tweet)
    {
        var html = HttpUtility.HtmlEncode(tweet.Text);

        //if there are any links in the tweet then replace with with an <a> element to the target            
        var links = tweet.Entities.UrlEntities;
        if (links != null && links.Any())
        {
            foreach (var link in links)
            {
                var encodedUrl = HttpUtility.HtmlEncode(link.Url);
                var elm = String.Format("<a href=\"{0}\" nofollow>{1}</a>", link.ExpandedUrl, HttpUtility.HtmlEncode(link.DisplayUrl));
                html = html.Replace(encodedUrl, elm);
            }
        }

        //if there are any hash tags then replace with them with <a> elements to the twitter search page
        var hashTags = tweet.Entities.HashTagEntities;
        if (hashTags == null || !hashTags.Any()) 
            return new MvcHtmlString(html);
        foreach (var tag in hashTags)
        {
            var encodedTag = HttpUtility.HtmlEncode(tag.Tag);
            var elm = String.Format("<a href=\"https://twitter.com/hashtag/{0}\" nofollow>#{1}</a>", HttpUtility.UrlEncode(tag.Tag), encodedTag);
            html = html.Replace("#" + encodedTag, elm);
        }

        return new MvcHtmlString(html);
    }

}
