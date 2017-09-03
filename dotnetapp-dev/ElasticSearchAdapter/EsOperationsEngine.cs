#region

#endregion

namespace DotnetApp.ElasticSearchAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using DotnetApp.AseFramework.Models;
    using DotnetApp.Controllers;
    using DotnetApp.ElasticSearchAdapter.UseCases;

    using Elasticsearch.Net;

    using Nest;

    public class EsOperationsEngine
    {
        private static ElasticClient _client;

        public static List<InteropTypes.V1.TweetModel> EsWriteAndReadbackTweet(InteropTypes.V1.TweetModel pTweetModel)
        {
            if (null == _client) _client = InitElasticClient();
            var client = _client;

            return WriteAndReadBackEsTweet.Execute(pTweetModel, client);
        }

        private static IGetResponse<InteropTypes.V1.TweetModel> ReadBackTweet11(ElasticClient client)
        {
// ok, now read back
            var response2 =
                client.Get<InteropTypes.V1.TweetModel>(11,
                    idx => idx
                        .Index("rtest")); // returns an IGetResponse mapped 1-to-1 with the Elasticsearch JSON response

            if (true != response2.ApiCall.Success)
                GeneralOperations.err_handling_bail_out(Console.Out, "ApiCall.Success != true");
            else
                Debug.WriteLine("es call successful");
            return response2;
        }

        private static ElasticClient InitElasticClient()
        {
            var nodes = new[]
            {
                new Uri("http://s0.wolfslab.wolfspool.at:9200/")
//                new Uri("http://es.wolfspool.chickenkiller.com/")
//                new Uri("http://10.0.0.100:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
            return client;
        }

        public static void DumpTweet(InteropTypes.V1.TweetModel obj)
        {
            Console.WriteLine(null != obj
                ? $"dumpTweet: {obj.Id} : {obj.User} // {obj.Value.Substring(0, 10)}..."
                : "obj is null");
        }
    }
}