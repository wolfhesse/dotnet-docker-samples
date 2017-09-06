#region using directives

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetApp.AseFramework.AbstractArchitecture.Definitions;
using DotnetApp.AseFramework.AbstractArchitecture.EnvironmentSetup;
using DotnetApp.AseFramework.Adapters.ElasticSearchAdapter;
using DotnetApp.AseFramework.Adapters.RabbitMqAdapter;
using DotnetApp.AseFramework.Core;
using DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET;
using DotnetApp.AseFramework.Models;
using DotnetApp.ProgramSetup;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp
{
    public class Program
    {
        public static int TweetsCounter = 0;

        public static void Main(string[] args)
        {
            var mqOperationsEngine = new MqOperationsEngine();
            mqOperationsEngine.Configure(new List<string> {"s0.wolfslab.wolfspool.at"});
            mqOperationsEngine.ConfigureMessageHandlers(ProcessProductCreatedMessage, CreateTweetHandler);
        }


        private static async void CreateTweetHandler(object sender, AseMessageEventArgs e)
        {
            // create 'tweet' in elasticsearch
            var t = BuildTweet(e.Message);
            await Task.Run(() => EsOperationsEngine.EsWriteAndReadbackTweet(t).ForEach(EsOperationsEngine.DumpTweet));
            EnvManager.WriteLine(e.Message);
        }

        private static InteropTypes.V1.Tweet BuildTweet(string message)
        {
            var t = new InteropTypes.V1.Tweet
            {
                PostDateTime = DateTimeOffset.Now.DateTime,

                // Id = tweets++,
                User = typeof(Program).ToString(),
                Value = message
            };
            return t;
        }

        private static async void ProcessProductCreatedMessage(object sender, AseMessageEventArgs eventArgs)
        {
            await Receive_EvMessageAsync(sender, eventArgs);
        }

        private static async Task Receive_EvMessageAsync(object sender, AseMessageEventArgs e)
        {
            try
            {
                // since Version 0.1.11 dup: tweet first (just to see, if anythink happens)
                // since Version 0.1.13 sync ops
                var t = BuildTweet(e.Message);
//                 Task.Run(() =>
                await Task.Run(() =>
                {
                    EsOperationsEngine.EsWriteAndReadbackTweet(t).ForEach(EsOperationsEngine.DumpTweet);
                    EnvManager.WriteLine(e.Message);
                });
                EnvManager.WriteLine("after tweet creation");

                // add product
                var p = new Product {name = e.Message, description = "demo produkt"};
                var restApi = PlatformInfo.WooStuffAuthAdapter.RestApiDefault();
                var shopEngine = new ShopEngine(new WooCommerceAdapter(), new WooCommerceConfiguration(restApi));

//                 Task.Run(() =>

                await Task.Run(() =>
                {
                    var startTs = DateTime.Now;
                    var p2 = shopEngine.AddProduct(p);
                    var duration = DateTime.Now - startTs;
                    EnvManager.WriteLine($"product created: {p2.name}" +
                                         $"{Environment.NewLine}" +
                                         $"\tduration: {duration.TotalSeconds} s");
                });
                EnvManager.WriteLine("after product creation");
                // }
            }
            catch (Exception ex)
            {
/*
                var t = BuildTweet(ex.Message);
//                 Task.Run(() =>
                await Task.Run(() =>
                    EsOperationsEngine.EsWriteAndReadbackTweet(t).ForEach(EsOperationsEngine.DumpTweet));
               */
                EnvManager.WriteLine(ex.Message);
                EnvManager.WriteLine("after tweet creating in catch-");
            }
        }
    }
}