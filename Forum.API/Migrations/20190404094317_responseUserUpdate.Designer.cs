﻿// <auto-generated />
using System;
using Forum.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190404094317_responseUserUpdate")]
    partial class responseUserUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Forum.API.Models.Discussion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("DocumentId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Status");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("Forum.API.Models.DiscussionParticipants", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DiscussionId");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.ToTable("DiscussionsParticipants");
                });

            modelBuilder.Entity("Forum.API.Models.DiscussionResponse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("DiscussionId");

                    b.Property<long?>("DocumentId");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Status");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("DiscussionResponses");
                });

            modelBuilder.Entity("Forum.API.Models.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Forum.API.Models.OrganizationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DiscussionParticipantsId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionParticipantsId");

                    b.ToTable("OrganizationType");
                });

            modelBuilder.Entity("Forum.API.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Forum.API.Models.Discussion", b =>
                {
                    b.HasOne("Forum.API.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("Forum.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Forum.API.Models.DiscussionParticipants", b =>
                {
                    b.HasOne("Forum.API.Models.Discussion", "Discussion")
                        .WithMany()
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Forum.API.Models.DiscussionResponse", b =>
                {
                    b.HasOne("Forum.API.Models.Discussion", "Discussion")
                        .WithMany("DiscussionResponses")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Forum.API.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("Forum.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Forum.API.Models.OrganizationType", b =>
                {
                    b.HasOne("Forum.API.Models.DiscussionParticipants", "DiscussionParticipants")
                        .WithMany("OrganizationType")
                        .HasForeignKey("DiscussionParticipantsId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
