﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DnsLib.AseFramework.AbstractArchitecture.Definitions;
    using DnsLib.AseFramework.AbstractArchitecture.EnvironmentSetup;
    using DnsLib.AseFramework.Core.Adapters.ElasticSearchAdapter;
    using DnsLib.AseFramework.Core.Adapters.RabbitMqAdapter;
    using DnsLib.AseFramework.Core.Components.ShopComponent;
    using DnsLib.AseFramework.Core.Components.ShopComponent.AseWooCommerceNET;
    using DnsLib.AseFramework.Core.Engines;
    using DnsLib.AseFramework.Models;

    using WooCommerceNET.WooCommerce.v2;

    using Version = DnsLib.AseFramework.Lib.Version;

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
            mqOperationsEngine.Configure(new List<string> { "s0.wolfslab.wolfspool.at" });
            mqOperationsEngine.ConfigureMessageHandlers(ProcessProductCreatedMessage, CreateTweetHandler);
        }

        /// <summary>The build tweet.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="InteropTypes.TweetModel"/>.</returns>
        private static InteropTypes.TweetModel BuildTweet(string message)
        {
            var t = new InteropTypes.TweetModel
                        {
                            PostDateTime = DateTimeOffset.Now.DateTime,

                            // Id = tweets++,
                            User = typeof(Program).ToString(),
                            Value = message
                        };

            // var addDescription = new AddDescription(t.Value);
            // Console.Out.WriteLine("addDescription = {0}", addDescription.DescriptionRecord.Id);
            return t;
        }

        /// <summary>The create tweet handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="aseMessageEventArgs">The ase message event args.</param>
        private static async void CreateTweetHandler(object sender, AseMessageEventArgs aseMessageEventArgs)
        {
            // create 'tweet' in elasticsearch
            var t = BuildTweet(aseMessageEventArgs.Message);
            await Task.Run(() => EsOperationsEngine.EsWriteAndReadbackTweet(t).ForEach(EsOperationsEngine.DumpTweet));
            EnvManager.WriteLine(aseMessageEventArgs.Message);

            // ## rq: DescriptionUseCase ##     new AddDescription(aseMessageEventArgs.Message);
        }

        /// <summary>The process product created message.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private static async void ProcessProductCreatedMessage(object sender, AseMessageEventArgs eventArgs)
        {
            await ReceiveEvMessageAsync(sender, eventArgs);
        }

        /// <summary>The receive_ ev message async.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private static async Task ReceiveEvMessageAsync(object sender, AseMessageEventArgs e)
        {
            try
            {
                // since Version 0.1.11 dup: tweet first (just to see, if anythink happens)
                // since Version 0.1.13 sync ops
                var t = BuildTweet(e.Message);

                // Task.Run(() =>
                await Task.Run(
                    () =>
                        {
                            EsOperationsEngine.EsWriteAndReadbackTweet(t).ForEach(EsOperationsEngine.DumpTweet);
                            EnvManager.WriteLine(e.Message);
                        });
                EnvManager.WriteLine("after tweet creation");

                // add product
                var p = new Product { name = e.Message, description = "demo produkt fuer V "+ Version.VERSION };
                var restApi = WooStuffAuthAdapter.RestApiDefault();
                var shopEngine = new ShopEngine(new WooCommerceAdapter(), new WooCommerceConfiguration(restApi));

                // Task.Run(() =>
                await Task.Run(
                    () =>
                        {
                            var startTs = DateTime.Now;
                            var p2 = shopEngine.AddProduct(p);
                            var duration = DateTime.Now - startTs;
                            EnvManager.WriteLine(
                                $"product created: {p2.name}" + $"{Environment.NewLine}"
                                + $"\tduration: {duration.TotalSeconds} s");
                        });
                EnvManager.WriteLine("after product creation");

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
                EnvManager.WriteLine(ex.Message);
                EnvManager.WriteLine("after tweet creating in catch-");
            }
        }
    }
}