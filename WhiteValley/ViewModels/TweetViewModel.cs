using System;
using System.Collections.Generic;


namespace WhiteValley.ViewModels
{
    public class TweetViewModel
    {

        public TweetViewModel()
        {
            Tweets = new Tweet[0];
            LastChecked = DateTime.UtcNow;
        }

        public IList<Tweet> Tweets { get; set; }

        public DateTime LastChecked { get; set; }

    }
}