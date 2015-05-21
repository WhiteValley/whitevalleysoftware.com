using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using LinqToTwitter;
using WhiteValley.ViewModels;


namespace WhiteValley.Controllers
{
    [RoutePrefix("tweets"), Route("{action=index}")]
    public class TweetController : Controller
    {

        [OutputCache(Duration = 86400)] //cache for a day
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var auth = new SingleUserAuthorizer
                {
                    CredentialStore = new SingleUserInMemoryCredentialStore
                    {
                        ConsumerKey = ConfigurationManager.AppSettings["Twitter.ConsumerKey"],
                        ConsumerSecret = ConfigurationManager.AppSettings["Twitter.ConsumerSecret"],
                        AccessToken = ConfigurationManager.AppSettings["Twitter.AccessToken"],
                        AccessTokenSecret = ConfigurationManager.AppSettings["Twitter.AccessTokenSecret"]
                    }
                };
                var twitterCtx = new TwitterContext(auth);

                var screenName = ConfigurationManager.AppSettings["Twitter.ScreenName"];


                var feed = (from tweet in twitterCtx.Status
                    where tweet.Type == StatusType.User && tweet.ScreenName == screenName && tweet.Favorited
                    select tweet)
                    .Take(5).ToList();


                var tweets = feed.Select(x => new Tweet
                {
                    Text = x.Text,
                    Html = x.ToHtml(),
                    TweetUrl = String.Format("https://twitter.com/{0}/status/{1}", screenName, x.StatusID),
                    AuthorUrl = String.Format("https://twitter.com/{0}", screenName),
                    CreatedAt = x.CreatedAt
                }).ToList();


                var model = new TweetViewModel
                {
                    Tweets = tweets
                };
                return PartialView(model);
            }
            catch
            {
                return PartialView(new TweetViewModel());
            }
            
        }


    }
}