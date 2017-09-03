#region

#endregion

namespace DotnetApp.AseFramework.Models
{
    using System;

    public class SampleDataProvider
    {
        public static string OnetabJsonEmptyState = @"{""tabGroups"":[]}";

        public static InteropTypes.V1.TweetModel GetSampleTweet()
        {
            var pTweet = new InteropTypes.V1.TweetModel
            {
                Id = null, // typeof(InteropTypes.V1.TweetModel) + ".GetSampleTweet",
//                Id = 1,
                User = "rogeraaut",
                PostDateTime = DateTime.Now,
                Value = "Trying out NEST, so far so good?"
            };
            return pTweet;
        }
    }
}