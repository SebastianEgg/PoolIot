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
using SnQPoolIot.Logic;
using SnQPoolIot.Contracts.Persistence.PoolIot;

namespace SnQPoolIot.WebApi
{
	public class Program
	{


        public static async Task Main(string[] args)
		{
            using var ctrl = Factory.Create<Contracts.Persistence.PoolIot.ISensorData>();
            var entity = await ctrl.CreateAsync();
            /*
            ISensorData sensorData = new SensorData();
            entity.SensorListId = 1;
            entity.Timestamp = "test";
            entity.Value = "test";
            await ctrl.InsertAsync(entity);
            await ctrl.SaveChangesAsync();
            Console.WriteLine(" Test");*/
            var res = await StartMqttClientAndRegisterObserverAsync();
            CreateHostBuilder(args).Build().Run();

            
            //var factory = new Factory();
            //var context = factory.CreateContext();
        }

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

        public static async Task<Task<int>> StartMqttClientAndRegisterObserverAsync()
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
            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e => MqttOnNewMessageAsync(e));
            mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(e => MqttOnConnected(e));
            mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(e => MqttOnDisconnected(e));

            await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).WithExactlyOnceQoS().Build());
            await mqttClient.StartAsync(mqttClientOptions);

            return Task.FromResult(0);
        }

        private static async Task MqttOnNewMessageAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            // Do something with each incoming message from the topic
            var mqttPayLoadData = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            string[] datavalue = mqttPayLoadData.Split(new char[] { ':',',','{','}' });

            using var ctrl = Factory.Create<Contracts.Persistence.PoolIot.ISensorData>();
            var entity = await ctrl.CreateAsync();


            for (int i = 0; i < datavalue.Length; i++)
            {
                if(i == 2)
                {

                    entity.Timestamp = datavalue[i].Trim();
                }
                else if(i == 4)
                {
                    entity.Value = datavalue[i].Trim();
                }
            }

            ISensorData sensorData = new SensorData();
            entity.SensorListId = 1;
            await ctrl.InsertAsync(entity);
            await ctrl.SaveChangesAsync();


            Console.WriteLine($"MQTT Client: OnNewMessage Topic: {e.ApplicationMessage.Topic} / Message: {mqttPayLoadData}");  

        }


        private static void MqttOnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Test");
            Console.WriteLine($"MQTT Client: Connected with result: {e.ConnectResult.ResultCode}");
        }
        private static void MqttOnDisconnected(MqttClientDisconnectedEventArgs e) => Console.WriteLine($"MQTT Client: Broker connection lost with reason: {e.Reason}.");
    }
}
