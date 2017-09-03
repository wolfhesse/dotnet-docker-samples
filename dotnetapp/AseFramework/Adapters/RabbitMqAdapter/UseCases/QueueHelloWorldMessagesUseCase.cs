// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueHelloWorldMessagesUseCase.cs" company="">
//   
// </copyright>
// <summary>
//   The queue hello world messages use case.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.RabbitMqAdapter.UseCases
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotnetApp.EnvironmentSetup;

    using RabbitMQ.Client;

    #endregion

    /// <summary>
    /// The queue hello world messages use case.
    /// </summary>
    public class QueueHelloWorldMessagesUseCase
    {
        /// <summary>
        /// The unmanaged messages queued counter.
        /// </summary>
        public static int UnmanagedMessagesQueuedCounter;

        /// <summary>
        /// The ev message queued.
        /// </summary>
        public static event EventHandler EvMessageQueued;

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="pMessageCount">
        /// The p message count.
        /// </param>
        /// <param name="engine">
        /// The engine.
        /// </param>
        /// <param name="testing">
        /// The testing.
        /// </param>
        public static void Execute(int pMessageCount, MqOperationsEngine engine, bool testing = false)
        {
            if (null == engine)
            {
                engine = new MqOperationsEngine();
                engine.ConfigureTestTest(new MessageQueueConfigEntry("s0.wolfslab.wolfspool.at"));
            }

            // var factory = //  new ConnectionFactory {HostName = hostName, UserName = "test", Password = "test"};
            using (var connection = engine.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", true, false, false, null);

                    var l = new List<int>();
                    for (var i = 0; i < pMessageCount; i++) l.Add(i);
                    l.ForEach(
                        i =>
                            {
                                var message = $"Hello World! : #{i}";
                                var body = Encoding.UTF8.GetBytes(message);
                                if (!testing)
                                {
                                    channel.BasicPublish(string.Empty, "hello", null, body);
                                    OnEvMessageQueued();
                                }

                                UnmanagedMessagesQueuedCounter++;

                                // Console.WriteLine(" [x] Sent {0}", message);
                            });
                }

                // Console.WriteLine(" Press [enter] to exit.");
                // Console.ReadLine();
            }
        }

        /// <summary>
        /// The on ev message queued.
        /// </summary>
        protected static void OnEvMessageQueued()
        {
            EvMessageQueued?.Invoke(typeof(QueueHelloWorldMessagesUseCase), EventArgs.Empty);
        }
    }
}