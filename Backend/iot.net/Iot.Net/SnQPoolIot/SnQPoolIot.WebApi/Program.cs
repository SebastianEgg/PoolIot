using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using SnQPoolIot.Transfer.Models.Persistence.PoolIot;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SnQPoolIot.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();

		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

        public static async Task<Task<int>> MQtt()
        {

            Console.WriteLine("SnQPoolIot");
            var mqttClientId = "PooliotClient";             // Unique ClientId or pass a GUID as string for something random
            var mqttBrokerAddress = "192.168.178.44";         // hostname or IP address of your MQTT broker
            var mqttBrokerUsername = "pi";       // Broker Auth username if using auth
            var mqttBrokerPassword = "egg21Pool";       // Broker Auth password if using auth
            var topic = "pooliot/noise/state";                 // topic to subscribe to

            var mqttClient = new MqttFactory().CreateManagedMqttClient();
            var mqttClientOptions = new ManagedMqttClientOptionsBuilder()
                        .WithAutoReconnectDelay(TimeSpan.FromSeconds(2))
                        .WithClientOptions(new MqttClientOptionsBuilder()
                            .WithTcpServer(mqttBrokerAddress, 1883)
                            .WithClientId(mqttClientId)
                            .WithCredentials(mqttBrokerUsername, mqttBrokerPassword)     // Remove this line if no auth
                            .WithCleanSession()
                            .Build()
                        )
                        .Build();

            Console.WriteLine(mqttClient);
            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e => MqttOnNewMessage(e));
            mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(e => MqttOnConnected(e));
            mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(e => MqttOnDisconnected(e));

            await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).WithExactlyOnceQoS().Build());
            await mqttClient.StartAsync(mqttClientOptions);
            Console.ReadLine();
            Console.ReadLine();




            return Task.FromResult(0);
        }

        private static  void MqttOnNewMessage(MqttApplicationMessageReceivedEventArgs e)
        {
            // Do something with each incoming message from the topic
            var eggerAgain = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Console.WriteLine($"MQTT Client: OnNewMessage Topic: {e.ApplicationMessage.Topic} / Message: {eggerAgain}");
            SensorData sensorData = new SensorData();
            
            sensorData.Id = 1;
            
            //sensorData.CreateAsync()

        }

        private static void MqttOnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Test");
            Console.WriteLine($"MQTT Client: Connected with result: {e.ConnectResult.ResultCode}");
        }
        private static void MqttOnDisconnected(MqttClientDisconnectedEventArgs e) => Console.WriteLine($"MQTT Client: Broker connection lost with reason: {e.Reason}.");

    }
}
