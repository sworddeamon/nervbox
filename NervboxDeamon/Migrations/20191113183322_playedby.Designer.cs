﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NervboxDeamon;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NervboxDeamon.Migrations
{
    [DbContext(typeof(NervboxDBContext))]
    [Migration("20191113183322_playedby")]
    partial class playedby
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NervboxDeamon.DbModels.Setting", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SettingScopeString")
                        .IsRequired()
                        .HasColumnName("SettingScope")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SettingTypeString")
                        .IsRequired()
                        .HasColumnName("SettingType")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("settings");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.Sound", b =>
                {
                    b.Property<string>("Hash")
                        .HasColumnName("hash")
                        .HasColumnType("text");

                    b.Property<bool>("Allowed")
                        .HasColumnName("allowed")
                        .HasColumnType("boolean");

                    b.Property<string>("FileName")
                        .HasColumnName("fileName")
                        .HasColumnType("text");

                    b.Property<long>("Size")
                        .HasColumnName("Size")
                        .HasColumnType("bigint");

                    b.Property<bool>("Valid")
                        .HasColumnName("valid")
                        .HasColumnType("boolean");

                    b.HasKey("Hash");

                    b.ToTable("sound");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.SoundUsage", b =>
                {
                    b.Property<DateTime>("Time")
                        .HasColumnName("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PlayedByUserId")
                        .HasColumnName("playedByUserId")
                        .HasColumnType("integer");

                    b.Property<string>("SoundHash")
                        .HasColumnName("soundhash")
                        .HasColumnType("text");

                    b.HasKey("Time");

                    b.HasIndex("PlayedByUserId");

                    b.HasIndex("SoundHash");

                    b.ToTable("soundusage");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("NervboxDeamon.DbModels.SoundUsage", b =>
                {
                    b.HasOne("NervboxDeamon.DbModels.User", "User")
                        .WithMany()
                        .HasForeignKey("PlayedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NervboxDeamon.DbModels.Sound", "Sound")
                        .WithMany("Usages")
                        .HasForeignKey("SoundHash");
                });
#pragma warning restore 612, 618
        }
    }
}