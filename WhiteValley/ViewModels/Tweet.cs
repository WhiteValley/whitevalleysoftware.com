using System;
using System.Web.Mvc;


namespace WhiteValley.ViewModels
{
    public class Tweet
    {

        public MvcHtmlString Html { get; set; }
        public string Text { get; set; }
        public string TweetUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorUrl { get; set; }

    }
}