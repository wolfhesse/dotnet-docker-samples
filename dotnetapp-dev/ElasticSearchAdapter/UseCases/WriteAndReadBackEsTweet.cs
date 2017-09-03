#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using dotnetapp.AseFramework.Controllers;
using dotnetapp.AseFramework.Models;
using Nest;

#endregion

namespace dotnetapp.ElasticSearchAdapter.UseCases
{
    internal class WriteAndReadBackEsTweet
    {
        public static List<InteropTypes.V1.TweetModel> Execute(InteropTypes.V1.TweetModel pTweetModel,
            ElasticClient client)
        {
            var tweet = pTweetModel;

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
            return new List<InteropTypes.V1.TweetModel> {tweet, tweet2};
        }
    }
}