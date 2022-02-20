﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Value")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("ActionLog", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("EnableJwtAuth")
                        .HasColumnType("bit");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TimeOutInMinutes")
                        .HasColumnType("int");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityXRole", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.LoginSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LogoutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OptionalInfo")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("SessionToken")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("LoginSession", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Designation")
                        .IsUnique();

                    b.ToTable("Role", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("User", "Account");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("SensorListId")
                        .HasColumnType("int");

                    b.Property<string>("Timestamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("SensorListId");

                    b.ToTable("SensorData", "PoolIot");
                });

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("SensorList", "PoolIot");
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
                    b.HasOne("SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorList", "SensorList")
                        .WithMany("SensorDatas")
                        .HasForeignKey("SensorListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SensorList");
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

            modelBuilder.Entity("SnQPoolIot.Logic.Entities.Persistence.PoolIot.SensorList", b =>
                {
                    b.Navigation("SensorDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
