namespace DotnetApp.AseFramework.Adapters.RabbitMqAdapter.UseCases
{
    #region using directives

    using System;
    using System.Text;
    using System.Threading;

    using DotnetApp.AseFramework.AbstractArchitecture.Definitions;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    #endregion

    /// <summary>
    ///     The consume mq messages loop use case.
    /// </summary>
    public class ConsumeMqMessagesLoopUseCase
    {
        /// <summary>
        ///     The ase message handler.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="eventArgs">
        ///     The event args.
        /// </param>
        public delegate void AseMessageHandler(object sender, AseMessageEventArgs eventArgs);

        /// <summary>
        ///     The ev rq tweet message.
        /// </summary>
        public static event AseMessageHandler EvRqTweetMessage;

        /// <summary>
        ///     The ev rq tweet product create message.
        /// </summary>
        public static event AseMessageHandler EvRqTweetProductCreateMessage;

        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="e">
        ///     The e.
        /// </param>
        public static void Execute(MqOperationsEngine e)
        {
            using (var connection = e.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", true, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);

                            Console.WriteLine(" [x] Received {0}...", message.Substring(0, 10));

                            var t = new Thread(
                                () =>
                                    {
                                        ProcessMessage(message);
                                        Console.WriteLine(" [x] Processed {0}...", message.Substring(0, 10));
                                    });
                            t.Start();

                            // t.Join();
                        };

                    channel.BasicConsume(
                        "hello",

                        // noAck: true,
                        true,
                        consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        ///     The on ev rq tweet message.
        /// </summary>
        /// <param name="eventargs">
        ///     The eventargs.
        /// </param>
        private static void OnEvRqTweetMessage(AseMessageEventArgs eventargs)
        {
            EvRqTweetMessage?.Invoke(null, eventargs);
        }

        // public class ProductCreatedEventArgs : EventArgs
        // {

        // }
        /// <summary>
        ///     The on ev rq tweet product create message.
        /// </summary>
        /// <param name="ea">
        ///     The ea.
        /// </param>
        private static void OnEvRqTweetProductCreateMessage(AseMessageEventArgs ea)
        {
            EvRqTweetProductCreateMessage?.Invoke(null, ea);
        }

        /// <summary>
        ///     The process message.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        private static void ProcessMessage(string message)
        {
            if (message.Contains("product created") || message.Contains("not Hello"))
            {
                var args = new AseMessageEventArgs(message);
                OnEvRqTweetProductCreateMessage(args);
            }
            else
            {
                var args = new AseMessageEventArgs(message);
                OnEvRqTweetMessage(args);
            }
        }
    }
}