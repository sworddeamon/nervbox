﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NervboxDeamon;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NervboxDeamon.Migrations
{
    [DbContext(typeof(NervboxDBContext))]
    partial class NervboxDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NervboxDeamon.DbModels.Setting", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("SettingScopeString")
                        .IsRequired()
                        .HasColumnName("SettingScope")
                        .HasMaxLength(50);

                    b.Property<string>("SettingTypeString")
                        .IsRequired()
                        .HasColumnName("SettingType")
                        .HasMaxLength(50);

                    b.Property<string>("Value");

                    b.HasKey("Key");

                    b.ToTable("settings");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.Sound", b =>
                {
                    b.Property<string>("Hash")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("hash");

                    b.Property<bool>("Allowed")
                        .HasColumnName("allowed");

                    b.Property<string>("FileName")
                        .HasColumnName("fileName");

                    b.Property<bool>("Valid")
                        .HasColumnName("valid");

                    b.HasKey("Hash");

                    b.ToTable("sound");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.SoundUsage", b =>
                {
                    b.Property<DateTime>("Time")
                        .HasColumnName("time");

                    b.Property<string>("Initiator")
                        .HasColumnName("initiator");

                    b.Property<string>("SoundHash")
                        .HasColumnName("soundhash");

                    b.HasKey("Time");

                    b.HasIndex("SoundHash");

                    b.ToTable("soundusage");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.SoundUsage", b =>
                {
                    b.HasOne("NervboxDeamon.DbModels.Sound", "Sound")
                        .WithMany("Usages")
                        .HasForeignKey("SoundHash");
                });
#pragma warning restore 612, 618
        }
    }
}
