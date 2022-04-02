using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SnQPoolIot.Transfer.Models.Persistence.PoolIot;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Text;
using System.Threading.Tasks;
using SnQPoolIot.Logic;
using SnQPoolIot.Contracts.Persistence.PoolIot;
using SnQPoolIot.WebApi.DataTransferObjects;
using SnQPoolIot.Logic.Entities.Business.Logging;

namespace SnQPoolIot.WebApi
{
    public class MqttActions
    {
        public event EventHandler<MqttMeasurementDto> OnMqttMessageReceived;
        public string currentTopic = "";
        public async Task<Task<int>> StartMqttClientAndRegisterObserverAsync(string specifiedTopic)
        {
            currentTopic = specifiedTopic;
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            Console.WriteLine("SnQPoolIot");
            Guid g = Guid.NewGuid();
            var mqttClientId = Convert.ToString(g);             // Unique ClientId
            var mqttBrokerAddress = configuration.GetValue<string>("Mqtt:mqttBrokerAddress");     // hostname or IP address of your MQTT broker
            var mqttBrokerUsername = configuration.GetValue<string>("Mqtt:mqttBrokerUsername");  // Broker Auth username
            var mqttBrokerPassword = configuration.GetValue<string>("Mqtt:mqttPassword");       // Broker Auth password
            var topic = configuration.GetValue<string>("Mqtt:mqttTopic") + specifiedTopic;      // topic to subscribe to

            var mqttClient = new MqttFactory().CreateManagedMqttClient();
            var mqttClientOptions = new ManagedMqttClientOptionsBuilder()
                        .WithAutoReconnectDelay(TimeSpan.FromSeconds(2))
                        .WithClientOptions(new MqttClientOptionsBuilder()
                            .WithTcpServer(mqttBrokerAddress, 1883)
                            .WithClientId(mqttClientId)
                            .WithCredentials(mqttBrokerUsername, mqttBrokerPassword)
                            .WithCleanSession()
                            .Build()
                        )
                        .Build();

            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e => MqttOnNewMessageAsync(e));
            mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(e => MqttOnConnected(e));
            mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(e => MqttOnDisconnected(e));

            await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).WithExactlyOnceQoS().Build());
            await mqttClient.StartAsync(mqttClientOptions);

            return Task.FromResult(0);
        }

        private async Task MqttOnNewMessageAsync(MqttApplicationMessageReceivedEventArgs e)
        {


            var mqttPayLoadData = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            string[] datavalue = mqttPayLoadData.Split(new char[] { ':', ',', '{', '}' });

            using var ctrl = Factory.Create<SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData>();
            var entity = await ctrl.CreateAsync();
            var measurment = new MqttMeasurementDto();

            entity.SensorId = GetSensorId(e);
            measurment.SensorId = entity.SensorId;
            measurment.SensorName = currentTopic;

            for (int i = 0; i < datavalue.Length; i++)
            {
                if (i == 2)
                {

                    measurment.Timestamp = DateTime.Now;
                }
                else if (i == 4)
                {
                    entity.Value = datavalue[i].Trim();
                    measurment.Value = entity.Value;
                }
            }

            OnMqttMessageReceived?.Invoke(this, measurment);

            await ctrl.InsertAsync(entity);
            await ctrl.SaveChangesAsync();

            LogWriter.Instance.LogWrite($"MQTT Client: OnNewMessage Topic: {e.ApplicationMessage.Topic} / Message: {mqttPayLoadData}");

        }


        private static void MqttOnConnected(MqttClientConnectedEventArgs e)
        {
            LogWriter.Instance.LogWrite($"MQTT Client: Connected with result: {e.ConnectResult.ResultCode}");
        }

        private static void MqttOnDisconnected(MqttClientDisconnectedEventArgs e)
        {
            LogWriter.Instance.LogWrite($"MQTT Client: Broker connection lost with reason: {e.Reason}.");
        }

        private static int GetSensorId(MqttApplicationMessageReceivedEventArgs e)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
            if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "neopixel/state"))
            {
                return 1;
            }
            else if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "noise/state"))
            {
                return 2;
            }
            else if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "temperature/state"))
            {
                return 3;
            }
            else if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "humidity/state"))
            {
                return 4;
            }
            else if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "pressure/state"))
            {
                return 5;
            }
            else if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "motion/state"))
            {
                return 6;
            }
            else if (e.ApplicationMessage.Topic == (configuration.GetValue<string>("Mqtt:mqttTopic") + "co2/state"))
            {
                return 7;
            }
            return -1;
        }
        private  void CallRuleEngine(int value)
        {
            if (currentTopic == "noise/state")
            {
                RuleEngine.CheckNoiceSensorData(value);
            }
        }
    }
}