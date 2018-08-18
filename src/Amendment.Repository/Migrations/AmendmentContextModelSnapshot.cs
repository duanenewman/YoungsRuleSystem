﻿// <auto-generated />
using System;
using Amendment.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Amendment.Repository.Migrations
{
    [DbContext(typeof(AmendmentContext))]
    partial class AmendmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("AmendTitle");

                    b.Property<int>("EnteredBy");

                    b.Property<DateTime>("EnteredDate");

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
                });

            modelBuilder.Entity("Amendment.Model.DataModel.UserXRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserXRole");
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
                    b.HasOne("Amendment.Model.DataModel.Amendment", "Amendment")
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
