// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Receive.cs" company="">
//   
// </copyright>
// <summary>
//   The receive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.RabbitMqAdapter
{
    #region

    using System;
    using System.Text;
    using System.Threading;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    #endregion

    /// <summary>
    /// The receive.
    /// </summary>
    public class Receive
    {
        /// <summary>
        /// The custom event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        public delegate void CustomEventHandler(object sender, CustomEventArgs eventArgs);

        /// <summary>
        /// The ev normal message.
        /// </summary>
        public static event CustomEventHandler EvNormalMessage;

        /// <summary>
        /// The ev product message.
        /// </summary>
        public static event CustomEventHandler EvProductMessage;

        /// <summary>
        /// The main entry point.
        /// </summary>
        public static void MainEntryPoint()
        {
            var factory = new ConnectionFactory
                              {
                                  HostName = "s0.wolfslab.local.wolfspool.at",
                                  UserName = "test",
                                  Password = "test"
                              };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", true, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);

                            Console.WriteLine(" [x] Received {0}", message);

                            var t = new Thread(
                                () =>
                                    {
                                        ProcessMessage(message);
                                        Console.WriteLine(" [x] Processed {0}", message);
                                    });
                            t.Start();
                            t.Join();
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
        /// The on ev normal message.
        /// </summary>
        /// <param name="eventargs">
        /// The eventargs.
        /// </param>
        private static void OnEvNormalMessage(CustomEventArgs eventargs)
        {
            EvNormalMessage?.Invoke(null, eventargs);
        }

        // public class ProductCreatedEventArgs : EventArgs
        // {

        // }
        /// <summary>
        /// The on ev product message.
        /// </summary>
        /// <param name="ea">
        /// The ea.
        /// </param>
        private static void OnEvProductMessage(CustomEventArgs ea)
        {
            EvProductMessage?.Invoke(null, ea);
        }

        /// <summary>
        /// The process message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        private static void ProcessMessage(string message)
        {
            if (message.Contains("product created"))
            {
                var args = new CustomEventArgs(message);
                OnEvProductMessage(args);
            }
            else
            {
                var args = new CustomEventArgs(message);
                OnEvNormalMessage(args);
            }
        }

        /// <summary>
        /// The custom event args.
        /// </summary>
        public class CustomEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CustomEventArgs"/> class.
            /// </summary>
            /// <param name="s">
            /// The s.
            /// </param>
            public CustomEventArgs(string s)
            {
                this.Message = s;
            }

            /// <summary>
            /// Gets the message.
            /// </summary>
            public string Message { get; }
        }
    }
}