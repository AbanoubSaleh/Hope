﻿// <auto-generated />
using System;
using Hope.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hope.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250414000642_add-needed-lookups")]
    partial class addneededlookups
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hope.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GovernmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Hope.Domain.Entities.Government", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameAr = "القاهرة",
                            NameEn = "Cairo",
                            PhoneCode = "02"
                        },
                        new
                        {
                            Id = 2,
                            NameAr = "الإسكندرية",
                            NameEn = "Alexandria",
                            PhoneCode = "03"
                        },
                        new
                        {
                            Id = 3,
                            NameAr = "الجيزة",
                            NameEn = "Giza",
                            PhoneCode = "02"
                        },
                        new
                        {
                            Id = 4,
                            NameAr = "القليوبية",
                            NameEn = "Qalyubia",
                            PhoneCode = "013"
                        },
                        new
                        {
                            Id = 5,
                            NameAr = "بورسعيد",
                            NameEn = "Port Said",
                            PhoneCode = "066"
                        },
                        new
                        {
                            Id = 6,
                            NameAr = "السويس",
                            NameEn = "Suez",
                            PhoneCode = "062"
                        },
                        new
                        {
                            Id = 7,
                            NameAr = "الأقصر",
                            NameEn = "Luxor",
                            PhoneCode = "095"
                        },
                        new
                        {
                            Id = 8,
                            NameAr = "أسوان",
                            NameEn = "Aswan",
                            PhoneCode = "097"
                        },
                        new
                        {
                            Id = 9,
                            NameAr = "أسيوط",
                            NameEn = "Assiut",
                            PhoneCode = "088"
                        },
                        new
                        {
                            Id = 10,
                            NameAr = "البحيرة",
                            NameEn = "Beheira",
                            PhoneCode = "045"
                        },
                        new
                        {
                            Id = 11,
                            NameAr = "بني سويف",
                            NameEn = "Beni Suef",
                            PhoneCode = "082"
                        },
                        new
                        {
                            Id = 12,
                            NameAr = "الدقهلية",
                            NameEn = "Dakahlia",
                            PhoneCode = "050"
                        },
                        new
                        {
                            Id = 13,
                            NameAr = "دمياط",
                            NameEn = "Damietta",
                            PhoneCode = "057"
                        },
                        new
                        {
                            Id = 14,
                            NameAr = "الفيوم",
                            NameEn = "Faiyum",
                            PhoneCode = "084"
                        },
                        new
                        {
                            Id = 15,
                            NameAr = "الغربية",
                            NameEn = "Gharbia",
                            PhoneCode = "040"
                        },
                        new
                        {
                            Id = 16,
                            NameAr = "الإسماعيلية",
                            NameEn = "Ismailia",
                            PhoneCode = "064"
                        },
                        new
                        {
                            Id = 17,
                            NameAr = "كفر الشيخ",
                            NameEn = "Kafr El Sheikh",
                            PhoneCode = "047"
                        },
                        new
                        {
                            Id = 18,
                            NameAr = "مطروح",
                            NameEn = "Matruh",
                            PhoneCode = "046"
                        },
                        new
                        {
                            Id = 19,
                            NameAr = "المنيا",
                            NameEn = "Minya",
                            PhoneCode = "086"
                        },
                        new
                        {
                            Id = 20,
                            NameAr = "المنوفية",
                            NameEn = "Monufia",
                            PhoneCode = "048"
                        },
                        new
                        {
                            Id = 21,
                            NameAr = "الوادي الجديد",
                            NameEn = "New Valley",
                            PhoneCode = "092"
                        },
                        new
                        {
                            Id = 22,
                            NameAr = "شمال سيناء",
                            NameEn = "North Sinai",
                            PhoneCode = "068"
                        },
                        new
                        {
                            Id = 23,
                            NameAr = "قنا",
                            NameEn = "Qena",
                            PhoneCode = "096"
                        },
                        new
                        {
                            Id = 24,
                            NameAr = "البحر الأحمر",
                            NameEn = "Red Sea",
                            PhoneCode = "065"
                        },
                        new
                        {
                            Id = 25,
                            NameAr = "الشرقية",
                            NameEn = "Sharqia",
                            PhoneCode = "055"
                        },
                        new
                        {
                            Id = 26,
                            NameAr = "سوهاج",
                            NameEn = "Sohag",
                            PhoneCode = "093"
                        },
                        new
                        {
                            Id = 27,
                            NameAr = "جنوب سيناء",
                            NameEn = "South Sinai",
                            PhoneCode = "069"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Hope.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Hope.Domain.Entities.Government", "Government")
                        .WithMany("Users")
                        .HasForeignKey("GovernmentId");

                    b.Navigation("Government");
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
                    b.HasOne("Hope.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Hope.Domain.Entities.ApplicationUser", null)
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

                    b.HasOne("Hope.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Hope.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hope.Domain.Entities.Government", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
