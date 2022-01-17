
using Microsoft.EntityFrameworkCore;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SnQPoolIot.ConApp
{
    internal partial class Program
    {

        #region Class-Constructors
        static Program()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        #endregion Class-Constructors

        private static void Main(/*string[] args*/)
        {

            Console.WriteLine(DateTime.Now);

            BeforeRun();

            AfterRun();
            Console.WriteLine(DateTime.Now);
        }


        private static void MqttOnNewMessage(MqttApplicationMessageReceivedEventArgs e)
        {
            // Do something with each incoming message from the topic
            var eggerAgain = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"MQTT Client: OnNewMessage Topic: {e.ApplicationMessage.Topic} / Message: {eggerAgain}");
             
        }

        private static void MqttOnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Test");
            Console.WriteLine($"MQTT Client: Connected with result: {e.ConnectResult.ResultCode}");
        }
        private static void MqttOnDisconnected(MqttClientDisconnectedEventArgs e) => Console.WriteLine($"MQTT Client: Broker connection lost with reason: {e.Reason}.");


        static partial void BeforeRun();
        static partial void AfterRun();
    }
}
//MdEnd
