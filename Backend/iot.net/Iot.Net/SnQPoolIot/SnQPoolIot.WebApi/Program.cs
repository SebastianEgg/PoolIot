using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SnQPoolIot.WebApi
{
    public class Program
    {



        public static void Main(string[] args)
        {

            RuleEngine ruleEngine = RuleEngine.Instance;
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
