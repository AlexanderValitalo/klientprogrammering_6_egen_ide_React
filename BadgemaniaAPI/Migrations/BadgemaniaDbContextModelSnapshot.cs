﻿// <auto-generated />
using System;
using BadgemaniaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BadgemaniaAPI.Migrations
{
    [DbContext(typeof(BadgemaniaDbContext))]
    partial class BadgemaniaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BadgeImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BadgegroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BadgetypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BadgegroupId");

                    b.HasIndex("BadgetypeId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badgegroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Badgegroups");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badgetype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BadgegroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BadgegroupId");

                    b.ToTable("Badgetypes");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

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

                    b.HasIndex("SchoolId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b383d2b5-5786-4188-b1b7-248ea6533cd9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "57db5a88-a4d7-43e4-88b9-e4ee41777fbd",
                            Email = "vagga@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VAGGA@ADMIN.COM",
                            NormalizedUserName = "VAGGA@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHDJzdMJNB+KQKe+QxuJDh/jLYcLkoOzYRHvWSR4JYsc7Z8nFqBCA9FPSqsD06dp8A==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "",
                            SchoolId = new Guid("213b864f-c265-491c-a2cb-77038bc93e26"),
                            SecurityStamp = "5ec2136b-c606-4d7c-8f5c-37e684cf11aa",
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TwoFactorEnabled = false,
                            UserName = "vagga@admin.com"
                        },
                        new
                        {
                            Id = "5f0da40b-c93e-4227-8747-45eaa53ccc78",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d732f560-f309-4c5e-9f92-d9ce7bc99a35",
                            Email = "vagga@teacher1.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VAGGA@TEACHER1.COM",
                            NormalizedUserName = "VAGGA@TEACHER1.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJUYOZCIj6sIyGecfASrWwxODcJdm4/BAfo+bITcrdsxIzFrjkjzmmh0XR4b1UxBMw==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "",
                            SchoolId = new Guid("213b864f-c265-491c-a2cb-77038bc93e26"),
                            SecurityStamp = "401f786f-4709-44a4-8d65-b2cb1e9e77ea",
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TwoFactorEnabled = false,
                            UserName = "vagga@teacher1.com"
                        },
                        new
                        {
                            Id = "ea5d94ef-655a-4565-bde4-f2098d4f81d1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5a71d8be-6228-40f6-8349-353cbdf16dbb",
                            Email = "vagga@student1.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VAGGA@STUDENT1.COM",
                            NormalizedUserName = "VAGGA@STUDENT1.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIIXifWl5wHi7ecsmwNN/FGI30+IqOK2tMp+Y93sIne2X9LLdlVY+F3UOSj4P8UtHg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "",
                            SchoolId = new Guid("213b864f-c265-491c-a2cb-77038bc93e26"),
                            SecurityStamp = "6a86ba86-703a-462c-898c-15b367d9f324",
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TwoFactorEnabled = false,
                            UserName = "vagga@student1.com"
                        });
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUserBadge", b =>
                {
                    b.Property<string>("CustomUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("BadgeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomUserId", "BadgeId");

                    b.HasIndex("BadgeId");

                    b.ToTable("CustomUserBadges");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUserBadgegroup", b =>
                {
                    b.Property<string>("CustomUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("BadgegroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomUserId", "BadgegroupId");

                    b.HasIndex("BadgegroupId");

                    b.ToTable("CustomUserBadgegroups");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Id = new Guid("213b864f-c265-491c-a2cb-77038bc93e26"),
                            Name = "Väggaskolan"
                        },
                        new
                        {
                            Id = new Guid("d8628307-3d6c-49bc-8c41-d53c482b1b93"),
                            Name = "Aleholmsskolan"
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

                    b.HasData(
                        new
                        {
                            Id = "30cfae89-ac70-4d27-a033-384bf4287716",
                            ConcurrencyStamp = "30cfae89-ac70-4d27-a033-384bf4287716",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "71c497af-4809-40f2-82c2-c770eb00150a",
                            ConcurrencyStamp = "71c497af-4809-40f2-82c2-c770eb00150a",
                            Name = "SchoolAdmin",
                            NormalizedName = "SCHOOLADMIN"
                        },
                        new
                        {
                            Id = "82f4b7a1-c728-4522-a51d-04741cdeee2a",
                            ConcurrencyStamp = "82f4b7a1-c728-4522-a51d-04741cdeee2a",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "f378e6ae-dbb3-415f-83ce-e069d4c16073",
                            ConcurrencyStamp = "f378e6ae-dbb3-415f-83ce-e069d4c16073",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "b383d2b5-5786-4188-b1b7-248ea6533cd9",
                            RoleId = "71c497af-4809-40f2-82c2-c770eb00150a"
                        },
                        new
                        {
                            UserId = "5f0da40b-c93e-4227-8747-45eaa53ccc78",
                            RoleId = "82f4b7a1-c728-4522-a51d-04741cdeee2a"
                        },
                        new
                        {
                            UserId = "ea5d94ef-655a-4565-bde4-f2098d4f81d1",
                            RoleId = "f378e6ae-dbb3-415f-83ce-e069d4c16073"
                        });
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

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badge", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.Badgegroup", "Badegroup")
                        .WithMany("Badges")
                        .HasForeignKey("BadgegroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BadgemaniaAPI.Models.Domain.Badgetype", "Badgetype")
                        .WithMany("Badges")
                        .HasForeignKey("BadgetypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Badegroup");

                    b.Navigation("Badgetype");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badgetype", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.Badgegroup", "Badgegroup")
                        .WithMany("Badgetypes")
                        .HasForeignKey("BadgegroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Badgegroup");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUser", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.School", "School")
                        .WithMany("CustomUsers")
                        .HasForeignKey("SchoolId");

                    b.Navigation("School");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUserBadge", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.Badge", "Badge")
                        .WithMany("CustomUserBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BadgemaniaAPI.Models.Domain.CustomUser", "CustomUser")
                        .WithMany("CustomUserBadges")
                        .HasForeignKey("CustomUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Badge");

                    b.Navigation("CustomUser");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUserBadgegroup", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.Badgegroup", "Badgegroup")
                        .WithMany("CustomUserBadgegroups")
                        .HasForeignKey("BadgegroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BadgemaniaAPI.Models.Domain.CustomUser", "CustomUser")
                        .WithMany("CustomUserBadgegroups")
                        .HasForeignKey("CustomUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Badgegroup");

                    b.Navigation("CustomUser");
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
                    b.HasOne("BadgemaniaAPI.Models.Domain.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.CustomUser", null)
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

                    b.HasOne("BadgemaniaAPI.Models.Domain.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BadgemaniaAPI.Models.Domain.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badge", b =>
                {
                    b.Navigation("CustomUserBadges");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badgegroup", b =>
                {
                    b.Navigation("Badges");

                    b.Navigation("Badgetypes");

                    b.Navigation("CustomUserBadgegroups");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.Badgetype", b =>
                {
                    b.Navigation("Badges");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.CustomUser", b =>
                {
                    b.Navigation("CustomUserBadgegroups");

                    b.Navigation("CustomUserBadges");
                });

            modelBuilder.Entity("BadgemaniaAPI.Models.Domain.School", b =>
                {
                    b.Navigation("CustomUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
