#region

#endregion

namespace DotnetApp.ElasticSearchAdapter.UseCases
{
    using System;
    using System.Collections.Generic;

    using DotnetApp.AseFramework.Models;
    using DotnetApp.Controllers;
    using DotnetApp.EnvironmentSetup;

    using Nest;

    internal class WriteAndReadBackEsTweet
    {
        public static List<InteropTypes.V1.TweetModel> Execute(InteropTypes.V1.TweetModel pTweetModel,
            ElasticClient client)
        {
            var tweet = pTweetModel;

            var response = client.Index(tweet, idx => idx.Index("rtest.current"));

            if (true != response.ApiCall.Success)
            {
                GeneralOperations.err_handling_bail_out(Console.Out, "ApiCall.Success != true");
            }
            else
            {
                var esCallSuccessful = "es call successful";
                EnvManager.DefaultOut.WriteLine(esCallSuccessful);
            }

            var tweet2 = tweet;
            return new List<InteropTypes.V1.TweetModel> {tweet, tweet2};
        }
    }
}