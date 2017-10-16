﻿// <auto-generated />
using CycloBit.Common.Enums;
using CycloBit.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CycloBit.Model.Migrations
{
    [DbContext(typeof(CycloBitContext))]
    partial class BicycleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("CycloBit")
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CycloBit.Model.Entities.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<int>("HouseNumber");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State")
                        .HasMaxLength(50);

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ContactPhone")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePhotoUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Detail")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.MedicalDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HeightCm");

                    b.Property<string>("IdentityUserId")
                        .IsRequired();

                    b.Property<double>("WeightKg");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("MedicalDetail");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Segment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ActivityId");

                    b.Property<string>("EncodedRoute");

                    b.Property<DateTime>("SegmentEnd");

                    b.Property<DateTime>("SegmentStart");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("Segment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Activity", b =>
                {
                    b.OwnsOne("CycloBit.Model.Entities.LatLng", "EndCoordinates", b1 =>
                        {
                            b1.Property<long?>("ActivityId");

                            b1.Property<double>("Lat");

                            b1.Property<double>("Lng");

                            b1.ToTable("Activity","CycloBit");

                            b1.HasOne("CycloBit.Model.Entities.Activity")
                                .WithOne("EndCoordinates")
                                .HasForeignKey("CycloBit.Model.Entities.LatLng", "ActivityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("CycloBit.Model.Entities.LatLng", "StartCoordinates", b1 =>
                        {
                            b1.Property<long?>("ActivityId");

                            b1.Property<double>("Lat");

                            b1.Property<double>("Lng");

                            b1.ToTable("Activity","CycloBit");

                            b1.HasOne("CycloBit.Model.Entities.Activity")
                                .WithOne("StartCoordinates")
                                .HasForeignKey("CycloBit.Model.Entities.LatLng", "ActivityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Address", b =>
                {
                    b.OwnsOne("CycloBit.Model.Entities.LatLng", "Coordinate", b1 =>
                        {
                            b1.Property<int>("AddressId");

                            b1.Property<double>("Lat");

                            b1.Property<double>("Lng");

                            b1.ToTable("Address","CycloBit");

                            b1.HasOne("CycloBit.Model.Entities.Address")
                                .WithOne("Coordinate")
                                .HasForeignKey("CycloBit.Model.Entities.LatLng", "AddressId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Location", b =>
                {
                    b.HasOne("CycloBit.Model.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CycloBit.Model.Entities.ApplicationUser")
                        .WithMany("SavedLocations")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("CycloBit.Model.Entities.MedicalDetail", b =>
                {
                    b.HasOne("CycloBit.Model.Entities.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CycloBit.Model.Entities.Segment", b =>
                {
                    b.HasOne("CycloBit.Model.Entities.Activity", "Activity")
                        .WithMany("Segments")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("CycloBit.Model.Entities.ActivityHealth", "ActivityHealth", b1 =>
                        {
                            b1.Property<long>("SegmentId");

                            b1.Property<float>("Distance");

                            b1.Property<float>("HeartBpm");

                            b1.ToTable("Segment","CycloBit");

                            b1.HasOne("CycloBit.Model.Entities.Segment")
                                .WithOne("ActivityHealth")
                                .HasForeignKey("CycloBit.Model.Entities.ActivityHealth", "SegmentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CycloBit.Model.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CycloBit.Model.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CycloBit.Model.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CycloBit.Model.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
