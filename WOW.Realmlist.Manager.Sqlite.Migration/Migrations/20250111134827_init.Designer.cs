﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WOW.RealmList.Manager.Domain;

#nullable disable

namespace WOW.RealmList.Manager.Sqlite.Migrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250111134827_init")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    partial class init
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WOW.RealmList.Manager.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<int>("ServerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("account", (string)null);
                });

            modelBuilder.Entity("WOW.RealmList.Manager.Domain.RealmList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("login");

                    b.Property<int>("ServerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("realm_list", (string)null);
                });

            modelBuilder.Entity("WOW.RealmList.Manager.Domain.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("server", (string)null);
                });

            modelBuilder.Entity("WOW.RealmList.Manager.Domain.Account", b =>
                {
                    b.HasOne("WOW.RealmList.Manager.Domain.Server", null)
                        .WithMany("Accounts")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WOW.RealmList.Manager.Domain.RealmList", b =>
                {
                    b.HasOne("WOW.RealmList.Manager.Domain.Server", null)
                        .WithMany("Realmlists")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WOW.RealmList.Manager.Domain.Server", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Realmlists");
                });
#pragma warning restore 612, 618
        }
    }
}
