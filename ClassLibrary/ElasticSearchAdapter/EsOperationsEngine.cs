using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClassLibrary.AseFramework.Controllers;
using ClassLibrary.AseFramework.Models;
using ClassLibrary.ElasticSearchAdapter.UseCases;
using Elasticsearch.Net;
using Nest;

namespace ClassLibrary.ElasticSearchAdapter
{
    public class EsOperationsEngine
    {
        private static ElasticClient _client;

        public static List<InteropTypes.V1.Tweet> EsWriteAndReadbackTweet(InteropTypes.V1.Tweet pTweet)
        {
            if (null == _client) _client = InitElasticClient();
            var client = _client;

            return WriteAndReadBackEsTweet.Execute(pTweet, client);
        }

        private static IGetResponse<InteropTypes.V1.Tweet> ReadBackTweet11(ElasticClient client)
        {
// ok, now read back
            var response2 =
                client.Get<InteropTypes.V1.Tweet>(11,
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
                new Uri("http://s0.wolfslab.local.wolfspool.at:9200/")
//                new Uri("http://es.wolfspool.chickenkiller.com/")
//                new Uri("http://10.0.0.100:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
            return client;
        }

        public static void DumpTweet(InteropTypes.V1.Tweet obj)
        {
            Console.WriteLine(null != obj ? $"dumpTweet: {obj.Id} : {obj.User} // {obj.Value}" : "obj is null");
        }
    }
}