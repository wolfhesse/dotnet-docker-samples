#region using directives

using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

#endregion

namespace DotnetApp.AseFramework.Adapters.RabbitMqAdapter.UseCases
{
    public class QueueMessages
    {
        public static void Execute(int pMessageCount, string hostName = "10.0.0.21")
        {
            var factory = new ConnectionFactory {HostName = hostName, UserName = "test", Password = "test"};
            using (var connection = factory.CreateConnection())
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
                        channel.BasicPublish("",
                            "hello",
                            null,
                            body);
//                    Console.WriteLine(" [x] Sent {0}", message);
                    });
                }

//            Console.WriteLine(" Press [enter] to exit.");
//            Console.ReadLine();
            }
        }
    }
}