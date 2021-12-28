//@GeneratedCode
namespace SnQPoolIot.Logic.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    partial class SnQPoolIotDbContext
    {
        protected DbSet<Entities.Persistence.PoolIot.SensorData> SensorDataSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.PoolIot.SensorList> SensorListSet
        {
            get;
            set;
        }
        partial void GetDbSet<I, E>(ref DbSet<E> dbSet) where E : class
        {
            if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorData))
            {
                dbSet = SensorDataSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.PoolIot.ISensorList))
            {
                dbSet = SensorListSet as DbSet<E>;
            }
        }
        static partial void DoModelCreating(ModelBuilder modelBuilder)
        {
            var sensorDataBuilder = modelBuilder.Entity<Entities.Persistence.PoolIot.SensorData>();
            sensorDataBuilder.ToTable("SensorData", "PoolIot")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.PoolIot.SensorData>().Property(p => p.RowVersion).IsRowVersion();
            sensorDataBuilder.Property(p => p.Value)
            .IsRequired()
            .HasMaxLength(256);
            sensorDataBuilder.Property(p => p.SensorListID)
            .IsRequired();
            sensorDataBuilder.Property(p => p.Timestamp)
            .IsRequired();
            ConfigureEntityType(sensorDataBuilder);
            var sensorListBuilder = modelBuilder.Entity<Entities.Persistence.PoolIot.SensorList>();
            sensorListBuilder.ToTable("SensorList", "PoolIot")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.PoolIot.SensorList>().Property(p => p.RowVersion).IsRowVersion();
            sensorListBuilder
            .HasIndex(c => c.Name)
            .IsUnique();
            sensorListBuilder.Property(p => p.Name)
            .HasMaxLength(128);
            sensorListBuilder
            .HasIndex(c => c.SensorID)
            .IsUnique();
            ConfigureEntityType(sensorListBuilder);
        }
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.PoolIot.SensorData> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.PoolIot.SensorList> entityTypeBuilder);
    }
}
