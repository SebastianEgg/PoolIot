using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SnQPoolIot.WebApi
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var resNeopixel = MqttActions.StartMqttClientAndRegisterObserverAsync("neopixel/state");
            var resNoise = MqttActions.StartMqttClientAndRegisterObserverAsync("noise/state");
            var resTemperature = MqttActions.StartMqttClientAndRegisterObserverAsync("temperature/state");
            var reshumidity = MqttActions.StartMqttClientAndRegisterObserverAsync("humidity/state");
            var resPressure = MqttActions.StartMqttClientAndRegisterObserverAsync("pressure/state");
            var resMotion = MqttActions.StartMqttClientAndRegisterObserverAsync("motion/state");
            var resCo2 = MqttActions.StartMqttClientAndRegisterObserverAsync("co2/state");
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
