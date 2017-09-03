// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MqOperationsEngine.cs" company="">
//   
// </copyright>
// <summary>
//   The mq operations engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.RabbitMqAdapter
{
    #region

    using System;
    using System.Diagnostics;

    using DotnetApp.AseFramework.Definitions;
    using DotnetApp.RabbitMqAdapter.UseCases;

    using RabbitMQ.Client;

    #endregion

    /// <summary>
    /// The mq operations engine.
    /// </summary>
    public class MqOperationsEngine
    {
        /// <summary>
        /// Gets a value indicating whether configured state.
        /// </summary>
        public bool ConfiguredState { get; private set; }

        /// <summary>
        /// Gets or sets the connection factory.
        /// </summary>
        public ConnectionFactory ConnectionFactory { get; set; }

        /// <summary>
        /// The configure test test.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public void ConfigureTestTest(EnvironmentSetup.MessageQueueConfigEntry config)
        {
            Debug.Assert(config.Purpose == ProgramConfigKeys.MessageQueue);
            this.ConnectionFactory =
                new ConnectionFactory { HostName = config.Hostname, UserName = "test", Password = "test" };

            // Console.WriteLine(ConnectionFactory);
            // Debug.WriteLine(ConnectionFactory);
            this.ConfiguredState = true;
        }

        /// <summary>
        /// The create connection.
        /// </summary>
        /// <returns>
        /// The <see cref="IConnection"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public IConnection CreateConnection()
        {
            if (!this.ConfiguredState) throw new Exception("configuration error");
            return this.ConnectionFactory.CreateConnection();
        }

        /// <summary>
        /// The execute with message handlers.
        /// </summary>
        /// <param name="processProductCreatedMessage">
        /// The process product created message.
        /// </param>
        /// <param name="createTweetHandler">
        /// The create tweet handler.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
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
    }
}