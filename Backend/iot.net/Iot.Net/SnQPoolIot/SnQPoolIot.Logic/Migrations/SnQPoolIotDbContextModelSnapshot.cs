// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SnQPoolIot.Logic.DataContext;

namespace SnQPoolIot.Logic.Migrations
{
    [DbContext(typeof(SnQPoolIotDbContext))]
    partial class SnQPoolIotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasMaxLength(4096)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("Access", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.ActionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("ActionLog", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EnableJwtAuth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeOutInMinutes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Identity", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.IdentityXRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityXRole", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.LoginSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LogoutTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("OptionalInfo")
                        .HasMaxLength(4096)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<string>("SessionToken")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("LoginSession", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("Designation")
                        .IsUnique();

                    b.ToTable("Role", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Firstname")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdentityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("User", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sensor", "PoolIot");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Timestamp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("SensorData", "PoolIot");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Access", b =>
                {
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("Accesss")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.ActionLog", b =>
                {
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("ActionLogs")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.IdentityXRole", b =>
                {
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("IdentityXRoles")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.Account.Role", "Role")
                        .WithMany("IdentityXRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.LoginSession", b =>
                {
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("LoginSessions")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.User", b =>
                {
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("Users")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorData", b =>
                {
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.PoolIot.Sensor", "Sensor")
                        .WithMany("SensorDatas")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", b =>
                {
                    b.Navigation("Accesss");

                    b.Navigation("ActionLogs");

                    b.Navigation("IdentityXRoles");

                    b.Navigation("LoginSessions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Role", b =>
                {
                    b.Navigation("IdentityXRoles");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.Sensor", b =>
                {
                    b.Navigation("SensorDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
