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
        protected DbSet<Entities.Persistence.Account.Access> AccessSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.ActionLog> ActionLogSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.Identity> IdentitySet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.IdentityXRole> IdentityXRoleSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.LoginSession> LoginSessionSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.Role> RoleSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.User> UserSet
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
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.IAccess))
            {
                dbSet = AccessSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.IActionLog))
            {
                dbSet = ActionLogSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.IIdentity))
            {
                dbSet = IdentitySet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.IIdentityXRole))
            {
                dbSet = IdentityXRoleSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.ILoginSession))
            {
                dbSet = LoginSessionSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.IRole))
            {
                dbSet = RoleSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(SnQPoolIot.Contracts.Persistence.Account.IUser))
            {
                dbSet = UserSet as DbSet<E>;
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
            ConfigureEntityType(sensorListBuilder);
            var accessBuilder = modelBuilder.Entity<Entities.Persistence.Account.Access>();
            accessBuilder.ToTable("Access", "Account")
            .HasKey("Id");
            accessBuilder
            .HasIndex(c => c.Key)
            .IsUnique();
            accessBuilder.Property(p => p.Key)
            .IsRequired()
            .HasMaxLength(512);
            accessBuilder.Property(p => p.Value)
            .HasMaxLength(4096);
            ConfigureEntityType(accessBuilder);
            var actionLogBuilder = modelBuilder.Entity<Entities.Persistence.Account.ActionLog>();
            actionLogBuilder.ToTable("ActionLog", "Account")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.ActionLog>().Property(p => p.RowVersion).IsRowVersion();
            ConfigureEntityType(actionLogBuilder);
            var identityBuilder = modelBuilder.Entity<Entities.Persistence.Account.Identity>();
            identityBuilder.ToTable("Identity", "Account")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.Identity>().Property(p => p.RowVersion).IsRowVersion();
            identityBuilder.Property(p => p.Guid)
            .IsRequired()
            .HasMaxLength(36);
            identityBuilder
            .HasIndex(c => c.Name)
            .IsUnique();
            identityBuilder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(128);
            identityBuilder
            .HasIndex(c => c.Email)
            .IsUnique();
            identityBuilder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(128);
            identityBuilder
            .Ignore(c => c.Password);
            ConfigureEntityType(identityBuilder);
            var identityXRoleBuilder = modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>();
            identityXRoleBuilder.ToTable("IdentityXRole", "Account")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>().Property(p => p.RowVersion).IsRowVersion();
            ConfigureEntityType(identityXRoleBuilder);
            var loginSessionBuilder = modelBuilder.Entity<Entities.Persistence.Account.LoginSession>();
            loginSessionBuilder.ToTable("LoginSession", "Account")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.LoginSession>().Property(p => p.RowVersion).IsRowVersion();
            loginSessionBuilder
            .Ignore(c => c.IsRemoteAuth);
            loginSessionBuilder
            .Ignore(c => c.Origin);
            loginSessionBuilder
            .Ignore(c => c.Name);
            loginSessionBuilder
            .Ignore(c => c.Email);
            loginSessionBuilder
            .Ignore(c => c.TimeOutInMinutes);
            loginSessionBuilder
            .Ignore(c => c.JsonWebToken);
            loginSessionBuilder.Property(p => p.SessionToken)
            .IsRequired()
            .HasMaxLength(128);
            loginSessionBuilder.Property(p => p.OptionalInfo)
            .HasMaxLength(4096);
            ConfigureEntityType(loginSessionBuilder);
            var roleBuilder = modelBuilder.Entity<Entities.Persistence.Account.Role>();
            roleBuilder.ToTable("Role", "Account")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.Role>().Property(p => p.RowVersion).IsRowVersion();
            roleBuilder
            .HasIndex(c => c.Designation)
            .IsUnique();
            roleBuilder.Property(p => p.Designation)
            .IsRequired()
            .HasMaxLength(64);
            roleBuilder.Property(p => p.Description)
            .HasMaxLength(256);
            ConfigureEntityType(roleBuilder);
            var userBuilder = modelBuilder.Entity<Entities.Persistence.Account.User>();
            userBuilder.ToTable("User", "Account")
            .HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.User>().Property(p => p.RowVersion).IsRowVersion();
            userBuilder
            .HasIndex(c => c.IdentityId)
            .IsUnique();
            userBuilder.Property(p => p.Firstname)
            .HasMaxLength(64);
            userBuilder.Property(p => p.Lastname)
            .HasMaxLength(64);
            ConfigureEntityType(userBuilder);
        }
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.PoolIot.SensorData> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.PoolIot.SensorList> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Access> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.ActionLog> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Identity> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.IdentityXRole> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.LoginSession> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Role> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.User> entityTypeBuilder);
    }
}
