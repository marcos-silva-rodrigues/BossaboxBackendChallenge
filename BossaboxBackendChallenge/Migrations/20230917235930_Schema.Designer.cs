﻿// <auto-generated />
using System;
using BossaboxBackendChallenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BossaboxBackendChallenge.Migrations
{
    [DbContext(typeof(ToolContext))]
    [Migration("20230917235930_Schema")]
    partial class Schema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("BossaboxBackendChallenge.Model.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BossaboxBackendChallenge.Model.Tool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("TagTool", b =>
                {
                    b.Property<Guid>("TagsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ToolsId")
                        .HasColumnType("TEXT");

                    b.HasKey("TagsId", "ToolsId");

                    b.HasIndex("ToolsId");

                    b.ToTable("TagTool");
                });

            modelBuilder.Entity("TagTool", b =>
                {
                    b.HasOne("BossaboxBackendChallenge.Model.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BossaboxBackendChallenge.Model.Tool", null)
                        .WithMany()
                        .HasForeignKey("ToolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}