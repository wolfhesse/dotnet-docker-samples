#region using directives

using System;
using System.Collections.Generic;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using DotnetApp.AseFramework.Adapters.ElasticSearchAdapter.UseCases;
using DotnetApp.AseFramework.Controllers;
using DotnetApp.AseFramework.Models;
using Elasticsearch.Net;
using Nest;

#endregion

namespace DotnetApp.AseFramework.Adapters.ElasticSearchAdapter
{
    #region using directives

    #endregion

    /// <summary>
    ///     The es operations engine.
    /// </summary>
    public class EsOperationsEngine
    {
        /// <summary>
        ///     The _client.
        /// </summary>
        private static ElasticClient _client;

        /// <summary>
        ///     The dump tweet.
        /// </summary>
        /// <param name="obj">
        ///     The obj.
        /// </param>
        public static void DumpTweet(InteropTypes.V1.TweetModel obj)
        {
            Console.WriteLine(
                // substring() wirft exception, wenn der string zu kurz is!
                null != obj ? $"dumpTweet: {obj.Id} : {obj.User} // {obj.Value.PadRight(10)}..." : "obj is null");
        }

        /// <summary>
        ///     The es write and readback tweet.
        /// </summary>
        /// <param name="pTweetModel">
        ///     The p tweet model.
        /// </param>
        /// <returns>
        ///     The
        ///     <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static List<InteropTypes.V1.TweetModel> EsWriteAndReadbackTweet(InteropTypes.V1.TweetModel pTweetModel)
        {
            if (null == _client) _client = InitElasticClient();
            var client = _client;

            return WriteAndReadBackEsTweet.Execute(pTweetModel, client);
        }

        /// <summary>
        ///     The init elastic client.
        /// </summary>
        /// <returns>
        ///     The <see cref="ElasticClient" />.
        /// </returns>
        private static ElasticClient InitElasticClient()
        {
            var nodes = new[]
            {
                new Uri("http://s0.wolfslab.wolfspool.at:9200/")

                // new Uri("http://es.wolfspool.chickenkiller.com/")
                // new Uri("http://10.0.0.100:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
            return client;
        }

        /// <summary>
        ///     The read back tweet 11.
        /// </summary>
        /// <param name="client">
        ///     The client.
        /// </param>
        /// <returns>
        ///     The
        ///     <see>
        ///         <cref>IGetResponse</cref>
        ///     </see>
        ///     .
        /// </returns>
        private static IGetResponse<InteropTypes.V1.TweetModel> ReadBackTweet11(ElasticClient client)
        {
            // ok, now read back
            var response2 =
                client.Get<InteropTypes.V1.TweetModel>(
                    11,
                    idx => idx.Index(
                        "rtest")); // returns an IGetResponse mapped 1-to-1 with the Elasticsearch JSON response

            if (true != response2.ApiCall.Success)
                GeneralOperations.ErrHandlingBailOut("ApiCall.Success != true");
            else EnvManager.WriteLine("es call successful");
            return response2;
        }
    }
}