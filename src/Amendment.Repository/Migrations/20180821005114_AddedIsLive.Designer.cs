﻿// <auto-generated />
using System;
using Amendment.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Amendment.Repository.Migrations
{
    [DbContext(typeof(AmendmentContext))]
    [Migration("20180821005114_AddedIsLive")]
    partial class AddedIsLive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Amendment.Model.DataModel.Amendment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AmendTitle")
                        .IsRequired();

                    b.Property<string>("Author");

                    b.Property<int>("EnteredBy");

                    b.Property<DateTime>("EnteredDate");

                    b.Property<bool>("IsLive");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("LastUpdatedBy");

                    b.Property<string>("LegisId");

                    b.Property<string>("Motion");

                    b.Property<int>("PrimaryLanguageId");

                    b.Property<string>("Source");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryLanguageId");

                    b.ToTable("Amendment");
                });

            modelBuilder.Entity("Amendment.Model.DataModel.AmendmentBody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AmendBody")
                        .IsRequired();

                    b.Property<int>("AmendId");

                    b.Property<int>("AmendStatus");

                    b.Property<int>("EnteredBy");

                    b.Property<DateTime>("EnteredDate");

                    b.Property<bool>("IsLive");

                    b.Property<int>("LanguageId");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("LastUpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("AmendId", "LanguageId");

                    b.ToTable("AmendmentBody");
                });

            modelBuilder.Entity("Amendment.Model.DataModel.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LanguageCode");

                    b.Property<string>("LanguageName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new { Id = 1, LanguageCode = "ENG", LanguageName = "English" },
                        new { Id = 2, LanguageCode = "SPA", LanguageName = "Spanish" },
                        new { Id = 3, LanguageCode = "FRA", LanguageName = "French" }
                    );
                });

            modelBuilder.Entity("Amendment.Model.DataModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnteredBy");

                    b.Property<DateTime>("EnteredDate");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("LastUpdatedBy");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = 1, EnteredBy = -1, EnteredDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdated = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdatedBy = -1, Name = "System Administrator" },
                        new { Id = 2, EnteredBy = -1, EnteredDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdated = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdatedBy = -1, Name = "Screen Controller" },
                        new { Id = 3, EnteredBy = -1, EnteredDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdated = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdatedBy = -1, Name = "Amendment Editor" },
                        new { Id = 4, EnteredBy = -1, EnteredDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdated = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdatedBy = -1, Name = "Translator" }
                    );
                });

            modelBuilder.Entity("Amendment.Model.DataModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("EnteredBy");

                    b.Property<DateTime>("EnteredDate");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("LastUpdatedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, Email = "admin@admin.com", EnteredBy = -1, EnteredDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdated = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), LastUpdatedBy = -1, Name = "Admin", Password = "$2b$12$HbvEC6UaeXiGGlv8ztvzL.SB6oBXKi2QoBkJsjwQvDJGpQ59CmWrq", Username = "admin" }
                    );
                });

            modelBuilder.Entity("Amendment.Model.DataModel.UserXRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserXRole");

                    b.HasData(
                        new { UserId = 1, RoleId = 1 }
                    );
                });

            modelBuilder.Entity("Amendment.Model.DataModel.Amendment", b =>
                {
                    b.HasOne("Amendment.Model.DataModel.Language", "PrimaryLanguage")
                        .WithMany()
                        .HasForeignKey("PrimaryLanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Amendment.Model.DataModel.AmendmentBody", b =>
                {
                    b.HasOne("Amendment.Model.DataModel.Amendment")
                        .WithMany("AmendmentBodies")
                        .HasForeignKey("AmendId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Amendment.Model.DataModel.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Amendment.Model.DataModel.UserXRole", b =>
                {
                    b.HasOne("Amendment.Model.DataModel.Role", "Role")
                        .WithMany("UserXRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Amendment.Model.DataModel.User", "User")
                        .WithMany("UserXRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
