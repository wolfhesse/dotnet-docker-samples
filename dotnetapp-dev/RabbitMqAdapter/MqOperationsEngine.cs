#region

#endregion

namespace DotnetApp.RabbitMqAdapter
{
    using System;
    using System.Diagnostics;

    using DotnetApp.AseFramework.Definitions;
    using DotnetApp.RabbitMqAdapter.UseCases;

    using RabbitMQ.Client;

    public class MqOperationsEngine
    {
        public bool ConfiguredState { get; private set; }
        public ConnectionFactory ConnectionFactory { get; set; }

        public void ConfigureTestTest(EnvironmentSetup.MessageQueueConfigEntry config)
        {
            Debug.Assert(config.Purpose == ProgramConfigKeys.MessageQueue);
            this.ConnectionFactory = new ConnectionFactory
            {
                HostName = config.Hostname,
                UserName = "test",
                Password = "test"
            };
            //            Console.WriteLine(ConnectionFactory);
            //            Debug.WriteLine(ConnectionFactory);
            this.ConfiguredState = true;
        }

        public void ExecuteWithMessageHandlers(
            ConsumeMqMessagesLoopUseCase.AseMessageHandler processProductCreatedMessage,
            ConsumeMqMessagesLoopUseCase.AseMessageHandler createTweetHandler)
        {
            if (this.ConfiguredState)
            {
                // routing
                // product created  -> create product in dependent store
                // both cases: create 'tweet' is es-index
                ConsumeMqMessagesLoopUseCase.EvRqTweetProductCreateMessage += processProductCreatedMessage;
                ConsumeMqMessagesLoopUseCase.EvRqTweetProductCreateMessage += createTweetHandler;

                ConsumeMqMessagesLoopUseCase.EvRqTweetMessage += createTweetHandler;

                ConsumeMqMessagesLoopUseCase.Execute(this);
            }
            else
            {
                throw new Exception("missing configuration");
            }
        }

        public IConnection CreateConnection()
        {
            if (!this.ConfiguredState)
                throw new Exception("configuration error");
            return this.ConnectionFactory.CreateConnection();
        }
    }
}