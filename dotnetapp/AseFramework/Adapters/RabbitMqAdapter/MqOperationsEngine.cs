#region using directives

using System;
using System.Collections.Generic;
using ClassLibrary.RabbitMqAdapter.UseCases;
using RabbitMQ.Client;

#endregion

namespace DotnetApp.AseFramework.Adapters.RabbitMqAdapter
{
    public class MqOperationsEngine
    {
        public bool ConfiguredState { get; private set; }
        public ConnectionFactory ConnectionFactory { get; set; }

        public void Configure(List<string> config)
        {
            ConnectionFactory = new ConnectionFactory
            {
                HostName = config[0],
                UserName = "test",
                Password = "test"
            };
//            Console.WriteLine(ConnectionFactory);
//            Debug.WriteLine(ConnectionFactory);
            ConfiguredState = true;
        }

        public void ConfigureMessageHandlers(ConsumeMqMessagesLoop.AseMessageHandler processProductCreatedMessage,
            ConsumeMqMessagesLoop.AseMessageHandler createTweetHandler)
        {
            if (ConfiguredState)
            {
                // routing
                // product created  -> create product in dependent store
                // both cases: create 'tweet' is es-index
                ConsumeMqMessagesLoop.EvRqTweetProductCreateMessage += processProductCreatedMessage;
//                ConsumeMqMessagesLoop.EvRqTweetProductCreateMessage += createTweetHandler;

                ConsumeMqMessagesLoop.EvRqTweetMessage += createTweetHandler;

                ConsumeMqMessagesLoop.Execute(this);
            }
            else
            {
                throw new Exception("missing configuration");
            }
        }

        public IConnection CreateConnection()
        {
            return ConnectionFactory.CreateConnection();
        }
    }
}