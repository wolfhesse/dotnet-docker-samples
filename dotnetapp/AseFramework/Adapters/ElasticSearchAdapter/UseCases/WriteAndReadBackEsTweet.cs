#region using directives

using System.Collections.Generic;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using DotnetApp.AseFramework.Controllers;
using DotnetApp.AseFramework.Models;
using Nest;

#endregion

namespace DotnetApp.AseFramework.Adapters.ElasticSearchAdapter.UseCases
{
    #region using directives

    #endregion

    /// <summary>
    ///     The write and read back es tweet.
    /// </summary>
    internal class WriteAndReadBackEsTweet
    {
        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="pTweetModel">
        ///     The p tweet model.
        /// </param>
        /// <param name="client">
        ///     The client.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public static List<InteropTypes.V1.TweetModel> Execute(
            InteropTypes.V1.TweetModel pTweetModel,
            ElasticClient client)
        {
            var tweet = pTweetModel;

            var response = client.Index(tweet, idx => idx.Index("rtest.current"));

            if (true != response.ApiCall.Success)
            {
                GeneralOperations.ErrHandlingBailOut("ApiCall.Success != true");
            }
            else
            {
                var esCallSuccessful = "es call successful";
                EnvManager.WriteLine(esCallSuccessful);
            }

            var tweet2 = tweet;
            return new List<InteropTypes.V1.TweetModel> {tweet, tweet2};
        }
    }
}