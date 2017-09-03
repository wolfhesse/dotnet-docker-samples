// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WriteAndReadBackEsTweet.cs" company="">
//   
// </copyright>
// <summary>
//   The write and read back es tweet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.ElasticSearchAdapter.UseCases
{
    #region

    using System;
    using System.Collections.Generic;

    using DotnetApp.AseFramework.Models;
    using DotnetApp.Controllers;
    using DotnetApp.EnvironmentSetup;

    using Nest;

    #endregion

    /// <summary>
    /// The write and read back es tweet.
    /// </summary>
    internal class WriteAndReadBackEsTweet
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="pTweetModel">
        /// The p tweet model.
        /// </param>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<InteropTypes.V1.TweetModel> Execute(
            InteropTypes.V1.TweetModel pTweetModel,
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
            return new List<InteropTypes.V1.TweetModel> { tweet, tweet2 };
        }
    }
}