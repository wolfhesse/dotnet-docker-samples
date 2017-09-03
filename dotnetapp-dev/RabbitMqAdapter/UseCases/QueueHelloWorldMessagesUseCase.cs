using ClassLibrary.EnvironmentSetup;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using dotnetapp.RabbitMqAdapter;

namespace ClassLibrary.RabbitMqAdapter.UseCases
{
    public class QueueHelloWorldMessagesUseCase
    {
        public static int UnmanagedMessagesQueuedCounter = 0;

        public static event EventHandler EvMessageQueued;
        public static void Execute(int pMessageCount, MqOperationsEngine engine, bool testing = false)
        {
            if (null == engine)
            {
                engine = new MqOperationsEngine();
                engine.ConfigureTestTest(new MessageQueueConfigEntry("s0.wolfslab.wolfspool.at"));
            }
            //            var factory = //  new ConnectionFactory {HostName = hostName, UserName = "test", Password = "test"};
            using (var connection = engine.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello",
                        true,
                        false,
                        false,
                        null);

                    var l = new List<int>();
                    for (var i = 0; i < pMessageCount; i++) l.Add(i);
                    l.ForEach(i =>
                    {
                        var message = $"Hello World! : #{i}";
                        var body = Encoding.UTF8.GetBytes(message);
                        if (!testing)
                        {
                            channel.BasicPublish("",
                                "hello",
                                null,
                                body);
                            OnEvMessageQueued();
                        }
                        UnmanagedMessagesQueuedCounter++;
                        
                        //                    Console.WriteLine(" [x] Sent {0}", message);
                    });
                }

                //            Console.WriteLine(" Press [enter] to exit.");
                //            Console.ReadLine();
            }
        }


        protected static void OnEvMessageQueued()
        {
            EvMessageQueued?.Invoke(typeof(QueueHelloWorldMessagesUseCase), EventArgs.Empty);
        }
    }
}