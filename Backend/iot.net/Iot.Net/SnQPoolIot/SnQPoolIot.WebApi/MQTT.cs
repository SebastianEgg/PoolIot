using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SnQPoolIot.Transfer.Models.Persistence.PoolIot;



public class MqttContext : DbContext
{
    public MqttContext(DbContextOptions<MqttContext> options) : base(options)
    {
    }

    public DbSet<SensorData> SensorDatas => Set<SensorData>();
}

public class MqttContextFactory : IDesignTimeDbContextFactory<MqttContext>
{
    public MqttContext CreateDbContext(string[]? args = null)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        var optionsBuilder = new DbContextOptionsBuilder<MqttContext>();
        optionsBuilder.UseSqlServer("Data Source=127.0.0.1,14330;Database=SnQPoolIotDb;User Id=sa; Password=passme!1234");

        return new MqttContext(optionsBuilder.Options);
    }
}