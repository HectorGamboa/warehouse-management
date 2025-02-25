﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WH.Infrastructure.Persistence.Context;

#nullable disable

namespace WH.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250225201211_Initial_DB_Migration")]
    partial class Initial_DB_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WH.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MenuId");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<int?>("FatherId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("WH.Domain.Entities.MenuRole", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("MenuId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("MenuRoles");
                });

            modelBuilder.Entity("WH.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PermissionId");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("WH.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WH.Domain.Entities.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("WH.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WH.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserRoleId");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("WH.Domain.Entities.MenuRole", b =>
                {
                    b.HasOne("WH.Domain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WH.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WH.Domain.Entities.Permission", b =>
                {
                    b.HasOne("WH.Domain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("WH.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("WH.Domain.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WH.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WH.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("WH.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WH.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
