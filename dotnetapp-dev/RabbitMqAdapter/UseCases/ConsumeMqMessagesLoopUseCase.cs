﻿namespace DotnetApp.RabbitMqAdapter.UseCases
{
    using System;
    using System.Text;
    using System.Threading;

    using DotnetApp.AseFramework.Definitions;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class ConsumeMqMessagesLoopUseCase
    {
        public delegate void AseMessageHandler(object sender, AseMessageEventArgs eventArgs);

        public static event AseMessageHandler EvRqTweetMessage;
        public static event AseMessageHandler EvRqTweetProductCreateMessage;

        public static void Execute(MqOperationsEngine e)
        {
            using (var connection = e.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello",
                        true,
                        false,
                        false,
                        null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(" [x] Received {0}...", message.Substring(0,10));

                        var t = new Thread(() =>
                        {
                            ProcessMessage(message);
                            Console.WriteLine(" [x] Processed {0}...", message.Substring(0,10));
                        });
                        t.Start();
//                        t.Join();
                    };

                    channel.BasicConsume("hello",
//                        noAck: true,
                        true,
                        consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }


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
        //        public class ProductCreatedEventArgs : EventArgs
        //        {

        //        }
        private static void OnEvRqTweetProductCreateMessage(AseMessageEventArgs ea)
        {
            EvRqTweetProductCreateMessage?.Invoke(null, ea);
        }

        private static void OnEvRqTweetMessage(AseMessageEventArgs eventargs)
        {
            EvRqTweetMessage?.Invoke(null, eventargs);
        }
    }
}