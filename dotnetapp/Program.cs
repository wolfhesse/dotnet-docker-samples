using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DnsLib;
using DnsLib.AbstractArchitecture.Definitions;
using DnsLib.ElasticSearchComponent;
using DnsLib.ShopComponent;
using WooCommerceNET.WooCommerce.v2;
using DnsLib.ShopComponent.AseWooCommerceNET;
using DnsLib.SysRes;

namespace DotnetApp
{
    #region using directives

    #endregion

    /// <summary>The program.</summary>
    public class Program
    {
        /// <summary>The tweets counter.</summary>
        public static int TweetsCounter = 0;

        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var mqOperationsEngine = new MqOperationsEngine();
            mqOperationsEngine.Configure(new List<string> {"10.0.0.100"});
            mqOperationsEngine.ConfigureMqMessagesLoopMessageHandlers(
                ProcessProductCreatedMessage,
                CreateTweetHandler).Execute(mqOperationsEngine);
        }

        /// <summary>The build tweet.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="InteropTypes.TweetModel" />.</returns>
        private static InteropTypes.TweetModel BuildTweet(string message)
        {
            var t0 = TweetEngine.FnCreateTweet(message);
            t0.User = typeof(Program).ToString();
            return t0;
        }

        /// <summary>The create tweet handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="aseMessageEventArgs">The ase message event args.</param>
        public static async void CreateTweetHandler(object sender, AseMessageEventArgs aseMessageEventArgs)
        {
            // create 'tweet' in elasticsearch
            var t = BuildTweet(aseMessageEventArgs.Message);
            await Task.Run(() => EsOperationsEngine.EsWriteAndDupTweet(t).ForEach(TweetEngine.DumpTweet))
                .ConfigureAwait(false);
            EnvironmentManager.WriteLine(aseMessageEventArgs.Message);

            // ## rq: DescriptionUseCase ##     new AddDescription(aseMessageEventArgs.Message);
        }

        /// <summary>The process product created message.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        public static async void ProcessProductCreatedMessage(object sender, AseMessageEventArgs eventArgs)
        {
            await ReceiveEvMessageAsync(sender, eventArgs);
        }

        /// <summary>The receive_ ev message async.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns>The <see cref="Task" />.</returns>
        private static async Task ReceiveEvMessageAsync(object sender, AseMessageEventArgs e)
        {
            EnvironmentManager.WriteLine($"{typeof(Program)}: got message from {sender} @ {DateTimeOffset.Now}");
            try
            {
                // since Version 0.1.11 dup: tweet first (just to see, if anythink happens)
                // since Version 0.1.13 sync ops
                var t = BuildTweet(e.Message);

                // Task.Run(() =>
                await Task.Run(
                    () =>
                    {
                        EsOperationsEngine.EsWriteAndDupTweet(t).ForEach(TweetEngine.DumpTweet);
//                        EnvironmentManager.WriteLine(e.Message);
                        EnvironmentManager.WriteLine("after tweet creation [inTask]");
                    });
                EnvironmentManager.WriteLine("after tweet creation [aftTask]");

                // add product
                var p = new Product {name = e.Message, description = "demo produkt fuer V " + VersionInfo.Version};

                var shopEngine1 = new ShopEngine(new WooCommerceAdapter(),
                    new WooCommerceConfiguration(
                        WooStuffAuthAdapter.FnRestApiRcs1()));
                var shopEngine2 = new ShopEngine(new WooCommerceAdapter(),
                    new WooCommerceConfiguration(
                        WooStuffAuthAdapter.FnRestApiRcs2()));
                var flipFlop = false;
                EnvironmentManager.WriteLine("\t\t\t--- 1 --- before product creation");
                // Task.Run(() =>
                await Task.Run(
                    () =>
                    {
                        flipFlop = !flipFlop;
                        var shopEngine = flipFlop ? shopEngine1 : shopEngine2;

                        EnvironmentManager.WriteLine($"\t\t\t--- 2 --- before product creation [inTask]");
                        EnvironmentManager.WriteLine($"\t\t\t          {shopEngine}");

                        var startTs = DateTime.Now;
                        var p2 = shopEngine.AddProduct(p);
                        var duration = DateTime.Now - startTs;
                        EnvironmentManager.WriteLine(
                            $"product created: {p2.name}" + $"{Environment.NewLine}"
                                                          + $"\tduration: {duration.TotalSeconds} s");
                        EnvironmentManager.WriteLine("after product creation [inTask]");
                    });
                EnvironmentManager.WriteLine("after product creation");

                // ## rq: DescriptionUseCase ##     new AddDescription("product :" + p.description);
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
                EnvironmentManager.WriteLine(ex.Message);
                EnvironmentManager.WriteLine("after tweet creating in catch-");
            }
        }
    }
}