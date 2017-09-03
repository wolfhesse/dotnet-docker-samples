using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.AseFramework.Controllers;
using ClassLibrary.AseFramework.Models;
using Nest;

namespace ClassLibrary.ElasticSearchAdapter.UseCases
{
    class WriteAndReadBackEsTweet
    {
        public static List<InteropTypes.V1.Tweet> Execute(InteropTypes.V1.Tweet pTweet, ElasticClient client)
        {
            var tweet = pTweet;

            var response = client.Index(tweet, idx => idx.Index("rtest.current"));

            if (true != response.ApiCall.Success)
                GeneralOperations.err_handling_bail_out(Console.Out, "ApiCall.Success != true");
            else
                Debug.WriteLine("es call successful");

//            tweet.Id = null;
//            response = client.Index(tweet, idx => idx.Index("rtest"));
//
//            if (true != response.ApiCall.Success)
//                GeneralOperations.err_handling_bail_out(Console.Out, "ApiCall.Success != true");
//            else
//                Debug.WriteLine("es call successful");


//            var response2 = ReadBackTweet11(client);
//            var tweet2 = response2.Source;
            var tweet2 = tweet;
            return new List<InteropTypes.V1.Tweet> {tweet, tweet2};
        }
    }
}
