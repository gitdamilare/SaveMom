﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaveMom.IdentityApp.Models;

#nullable disable

namespace SaveMom.IdentityApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221027182030_intial_create")]
    partial class intial_create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SaveMom.IdentityApp.Models.AppRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUserRole")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("AppRole");

                    b.HasData(
                        new
                        {
                            Id = "94108f28-b9ac-4ad0-a069-c3ab8613aff3",
                            ConcurrencyStamp = "f35f1c71-a7ce-46c1-8dc5-790bb1c44795",
                            Name = "Admin",
                            NormalizedName = "Admin",
                            Category = "Admin",
                            IsUserRole = false
                        },
                        new
                        {
                            Id = "1c773b50-f979-41c9-9209-e2f8b00501f4",
                            ConcurrencyStamp = "234669ca-39c5-46ba-8e56-a34c11784ddb",
                            Name = "SubAdmin",
                            NormalizedName = "SubAdmin",
                            Category = "Admin",
                            IsUserRole = false
                        },
                        new
                        {
                            Id = "6b1bdb24-0c40-4fa1-a5d8-52e147ea1ebb",
                            ConcurrencyStamp = "18755597-02d9-454c-b4d8-5b230b14fbd1",
                            Name = "Doctor",
                            NormalizedName = "Doctor",
                            Category = "User",
                            IsUserRole = true
                        },
                        new
                        {
                            Id = "a099b82e-40eb-4aaa-915a-d6a43052077b",
                            ConcurrencyStamp = "26fa685c-2373-44ea-9a31-0ca0991752a5",
                            Name = "HealthCareProvider",
                            NormalizedName = "Health Care Provider",
                            Category = "User",
                            IsUserRole = true
                        },
                        new
                        {
                            Id = "1829528e-4314-4ed2-a05a-57418fe7c872",
                            ConcurrencyStamp = "842f06a1-18e6-43a3-8bd5-abada0d1fdaa",
                            Name = "Ministry ",
                            NormalizedName = "Ministry",
                            Category = "Manager",
                            IsUserRole = true
                        });
                });

            modelBuilder.Entity("SaveMom.IdentityApp.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IdentityDocumentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasDiscriminator().HasValue("AppUser");

                    b.HasData(
                        new
                        {
                            Id = "00bcc664-8e54-49cf-bd26-13796fc2ec05",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "282d40a4-81de-4651-b7f9-d9fac708e9f7",
                            Email = "GENEVA.MILLS54@GMAIL.COM",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "GENEVA.MILLS54@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJEMWlkMFxTxyajwZKSOCJHPkUqcCJY2OjUgyqIYNkCZdAnXFXv8hZj7Q27YWmygGA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a15a3a1f-3667-415f-90cd-f1ac68522b4d",
                            TwoFactorEnabled = false,
                            UserName = "Geneva.Mills54@gmail.com",
                            FirstName = "Geneva",
                            LastName = "Mills"
                        },
                        new
                        {
                            Id = "b4e1609e-d661-4a9d-97b4-abd1220b05a7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0f5355b8-5866-4176-a256-dc45b9e810e9",
                            Email = "OMAR_MILLS@HOTMAIL.COM",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "OMAR_MILLS@HOTMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEAR8euRF4enlSwYcxb6FaEfGmnRAkQx727azL3KMksKX8k3VcWVc4PTEhwD6wUr7SQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6653805d-b7cc-425e-bc4d-b3087f1e27e7",
                            TwoFactorEnabled = false,
                            UserName = "Omar_Mills@hotmail.com",
                            FirstName = "Omar",
                            LastName = "Mills"
                        },
                        new
                        {
                            Id = "b70a2f8a-7869-4482-9cb9-3abeca6ba1da",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3850f064-c785-4839-883d-eb8e0ebd0be2",
                            Email = "DEBRA.RAU@HOTMAIL.COM",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "DEBRA.RAU@HOTMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMuRmiXX/SJvJODN3sH9wa0PO1LWdS1fnQmHdZ/z+xVJYYpXtgsxXIyOtsdeRKGKiQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a20fc75b-5d1e-40bc-9a35-dc24d9c3577e",
                            TwoFactorEnabled = false,
                            UserName = "Debra.Rau@hotmail.com",
                            FirstName = "Debra",
                            LastName = "Rau"
                        },
                        new
                        {
                            Id = "3c71d3a3-cc24-4ebd-bd29-943c2086bc12",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "35dae5ae-d616-4fd2-8959-946da9ef3a38",
                            Email = "NICHOLAS21@YAHOO.COM",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "NICHOLAS21@YAHOO.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEC+LxKPyE97Db2AW8SMiu2jY50bERwfZYreiECoeP+J+oXF3ic7TAX6MQwKRx3PPQQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b263fc3a-d9cc-4be9-a40e-98153aabd111",
                            TwoFactorEnabled = false,
                            UserName = "Nicholas21@yahoo.com",
                            FirstName = "Nicholas",
                            LastName = "Boehm"
                        },
                        new
                        {
                            Id = "09973040-681e-4b7e-91d8-5daa2fc37c45",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1e49bee5-767f-4adb-8a73-d5bafa7227a2",
                            Email = "IRVIN75@GMAIL.COM",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "IRVIN75@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFLXO7w/mfbWx73w2detc0Lx8JUTRyiMDXz8cGMrnnvYkHQBF/XXuVNhSJaLNHozLg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6fd24e67-9193-4521-821a-c4dd2976dc04",
                            TwoFactorEnabled = false,
                            UserName = "Irvin75@gmail.com",
                            FirstName = "Irvin",
                            LastName = "Pacocha"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
