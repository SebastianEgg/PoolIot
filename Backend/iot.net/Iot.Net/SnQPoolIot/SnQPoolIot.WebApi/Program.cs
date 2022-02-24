using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SnQPoolIot.WebApi
{
    public class Program
    {



        public static void Main(string[] args)
        {
            var mqttActions = new MqttActions();
            var resNeopixel = mqttActions.StartMqttClientAndRegisterObserverAsync("neopixel/state");
            var resNoise = mqttActions.StartMqttClientAndRegisterObserverAsync("noise/state");
            var resTemperature = mqttActions.StartMqttClientAndRegisterObserverAsync("temperature/state");
            var reshumidity = mqttActions.StartMqttClientAndRegisterObserverAsync("humidity/state");
            var resPressure = mqttActions.StartMqttClientAndRegisterObserverAsync("pressure/state");
            var resMotion = mqttActions.StartMqttClientAndRegisterObserverAsync("motion/state");
            var resCo2 = mqttActions.StartMqttClientAndRegisterObserverAsync("co2/state");
            CreateHostBuilder(args).Build().Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
