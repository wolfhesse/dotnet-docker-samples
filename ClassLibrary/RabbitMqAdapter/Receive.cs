﻿using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ClassLibrary.AseFramework.RabbitMqAdapter
{
    public class Receive
    {
        public delegate void CustomEventHandler(object sender, CustomEventArgs eventArgs);

        public static event CustomEventHandler EvNormalMessage;
        public static event CustomEventHandler EvProductMessage;

        public static void Main()
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

                        Console.WriteLine(" [x] Received {0}", message);

                        var t = new Thread(() =>
                        {
                            ProcessMessage(message);
                            Console.WriteLine(" [x] Processed {0}", message);
                        });
                        t.Start();
                        t.Join();
                    };

                    channel.BasicConsume(queue: "hello",
//                        noAck: true,
                        autoAck: true,
                        consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }


        private static void ProcessMessage(string message)
        {
            if (message.Contains("product created"))
            {
                var args = new CustomEventArgs(message);
                OnEvProductMessage(ea: args);
            }
            else
            {
                var args = new CustomEventArgs(message);
                OnEvNormalMessage(args);
            }
        }

        public class CustomEventArgs : EventArgs
        {
            public CustomEventArgs(string s)
            {
                msg = s;
            }

            private string msg;

            public string Message
            {
                get { return msg; }
            }
        }
        //        public class ProductCreatedEventArgs : EventArgs
        //        {

        //        }
        private static void OnEvProductMessage(CustomEventArgs ea)
        {
            EvProductMessage?.Invoke(null, ea);
        }

        private static void OnEvNormalMessage(CustomEventArgs eventargs)
        {
            EvNormalMessage?.Invoke(null, eventargs);
        }
    }
}