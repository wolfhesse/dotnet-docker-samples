using System;

namespace ClassLibrary.AseFramework.Models
{
    public class SampleDataProvider
    {
        public static InteropTypes.V1.Tweet GetSampleTweet()
        {
            var pTweet = new InteropTypes.V1.Tweet
            {
                Id = null, // typeof(InteropTypes.V1.Tweet) + ".GetSampleTweet",
//                Id = 1,
                User = "rogeraaut",
                PostDateTime = DateTime.Now,
                Value = "Trying out NEST, so far so good?"
            };
            return pTweet;
        }

        public static string OnetabJsonEmptyState = @"{""tabGroups"":[]}";
    }
}