using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DnsLib;
using DnsLib.AbstractArchitecture.AseArchitecture.Definitions;
using DnsLib.ComponentLibrary.Macrolib;
using DnsLib.FactoryFloor.MqComponent;
using DnsLib.FactoryFloor.ShopComponent;
using DnsLib.FactoryFloor.ShopComponent.AseWooCommerceNET;
using DnsLib.OperatorApps.SysRes;
using Newtonsoft.Json;
using WooCommerceNET.WooCommerce.v2;

namespace DotnetApp
{
    #region using directives

    #endregion

    public class BusinessCartridge
    {
        /// <summary>The tweets counter.</summary>
        public static int TweetsCounter = 0;

        private static bool _flipFlop;

        /// <summary>The build tweet.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="InteropTypes.TweetModel" />.</returns>
        public static async Task<InteropTypes.TweetModel> StoreMessageToEsIndexTask(string message)
        {
            var t0 = TweetEngine.FnCreateTweet(message);
            t0.User = typeof(Program).ToString();

            await Task.Run(() => EsOperationsEngine.EsWriteAndDupTweet(t0).ForEach(TweetEngine.DumpTweet))
                .ConfigureAwait(false);
            EnvironmentManager.WriteLine(message);

            return t0;
        }

        /// <summary>The receive_ ev message async.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns>The <see cref="Task" />.</returns>
        internal static async Task CreateWooDemoProductsTask(object sender, AseMessageEventArgs e)
        {
            EnvironmentManager.WriteLine($"{typeof(Program)}: got message from {sender} @ {DateTimeOffset.Now}");
            try
            {
                // since Version 0.1.11 dup: tweet first (just to see, if anythink happens)
                // since Version 0.1.13 sync ops

                // Task.Run(() =>
                await Task.Run(
                    () =>
                    {
                        EsOperationsEngine.EsWriteAndDupTweet(StoreMessageToEsIndexTask(e.Message).Result)
                            .ForEach(TweetEngine.DumpTweet);
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

                EnvironmentManager.WriteLine("\t\t\t--- 1 --- before product creation");
                // Task.Run(() =>
                await Task.Run(
                    () =>
                    {
                        _flipFlop = !_flipFlop;
                        var shopEngine = _flipFlop ? shopEngine1 : shopEngine2;

                        EnvironmentManager.WriteLine($"\t\t\t--- 2 --- before product creation [inTask]");
                        EnvironmentManager.WriteLine($"\t\t\t          ::::: {shopEngine.Configuration.ConfigName}");

                        var startTs = DateTime.Now;
                        var p2 = shopEngine.AddProduct(p);
                        var duration = DateTime.Now - startTs;
                        EnvironmentManager.WriteLine(
                            $"product created: {p2.name}" + $"{Environment.NewLine}"
                                                          + $"\tduration: {duration.TotalSeconds} s");
                        EnvironmentManager.WriteLine($"\t\t\t\t\t\t--- 2 --- after product creation [inTask]");
                        EnvironmentManager.WriteLine(
                            $"\t\t\t\t\t\t          ::::: {shopEngine.Configuration.ConfigName}");
                    });
                EnvironmentManager.WriteLine("\t\t\t\t\t\t--- 1 --- after product creation");

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

    /// <summary>The program.</summary>
    public class Program
    {
        /// <summary>The process product created message.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        public static async void HandleProductCreationRequest(object sender, AseMessageEventArgs eventArgs)
        {
            await BusinessCartridge.CreateWooDemoProductsTask(sender, eventArgs);
        }

        /// <summary>The create tweet handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="aseMessageEventArgs">The ase message event args.</param>
        public static async void HandleTweetCreationRequest(object sender, AseMessageEventArgs aseMessageEventArgs)
        {
            // create 'tweet' in elasticsearch
            var t = await BusinessCartridge.StoreMessageToEsIndexTask(aseMessageEventArgs.Message);
            EnvironmentManager.WriteLine($"Business Cartridge stored message {JsonConvert.SerializeObject(t)} ");

            // ## rq: DescriptionUseCase ##     new AddDescription(aseMessageEventArgs.Message);
        }

        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var mqOperationsEngine = new MqOperationsEngine();
            // server, gracetime, limit, queue

            mqOperationsEngine.Configure(new List<string>
            {
//                "s0.wolfslab.wolfspool.at", "30", "10", "hello"
                "10.0.0.100",
                "30",
                "10000",
                "hello"
            });
            mqOperationsEngine.ConfigureMqMessagesLoopMessageHandlers(
                    HandleProductCreationRequest,
                    HandleTweetCreationRequest)
                .Execute(mqOperationsEngine);
        }
    }
}