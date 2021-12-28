using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Serilog;

namespace HomeAutomation.Services
{
    public class MqttService : IMqttService
    {
        private IMqttClientOptions _mqttClientOptions;
        private string _clientId;

        public MqttService()
        {
        }

        public void Init(string serverUrl, int port, string mqttUser, string mqttPassword,
            Action<string, string, int, bool> receivedMqttMessageHandler)
        {
            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            _clientId = $"MqttSqlMapper_{Guid.NewGuid()}";

            // Create TCP based options using the builder.
            _mqttClientOptions = new MqttClientOptionsBuilder()
                .WithClientId(_clientId)
                .WithTcpServer(serverUrl, port)
                .WithCredentials(mqttUser, mqttPassword)
                .WithTls(new MqttClientOptionsBuilderTlsParameters 
                    { 
                    AllowUntrustedCertificates = true,
                    IgnoreCertificateChainErrors = true,
                    IgnoreCertificateRevocationErrors = true,
                    UseTls = true,
                    SslProtocol = System.Security.Authentication.SslProtocols.Tls12  //  neu mit MQTTnet 3.0.15
                })
                .WithCleanSession()
                //.WithCommunicationTimeout(TimeSpan.FromSeconds(2))
                .Build();
            mqttClient.UseApplicationMessageReceivedHandler(mqttEvent =>
            {
                string topic = mqttEvent.ApplicationMessage.Topic;
                string payload = Encoding.UTF8.GetString(mqttEvent.ApplicationMessage.Payload);
                var qos = mqttEvent.ApplicationMessage.QualityOfServiceLevel;
                var retained = mqttEvent.ApplicationMessage.Retain;
                if (retained)
                {
                    return;
                }
                Log.Information("Mqtt message received, topic: {topic}, payload: {payload}",
                    topic, payload);
                receivedMqttMessageHandler(topic, payload, (int)qos, retained);
            });

            mqttClient.UseConnectedHandler(async e =>
            {
                Log.Information("Mqtt connected");
                // Subscribe to all topics
                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("#").Build());
                Log.Information("all topics subscribed"); 
            });
            mqttClient.UseDisconnectedHandler(async e =>
            {
                Log.Error("Mqtt disconnected, {Reasoncode}", e.Reason);
                // Reconnect
                await mqttClient.ConnectAsync(_mqttClientOptions, CancellationToken.None); // Since 3.0.5 with CancellationToken
            });
            try
            {
                mqttClient.ConnectAsync(_mqttClientOptions, CancellationToken.None).Wait(); // Since 3.0.5 with CancellationToken
            }
            catch (Exception ex)
            {
                Log.Error("MqttService, Init, Exception: {Exception}", ex.Message);
                StringBuilder innerExceptionMessages = new StringBuilder();
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    innerExceptionMessages.Append(innerEx.Message);
                    innerExceptionMessages.Append('*');
                    innerEx = innerEx.InnerException;
                }
                Log.Error("MqttService, Init, InnerExceptions: {InnerException}", innerExceptionMessages.ToString());
            }
            Log.Information("MqttService; Init(); MqttClientId: {MqttClientId} ", _clientId);
        }

    }
}
