﻿// <auto-generated />
using System;
using Emsa.Mared.Discussions.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Discussions.API.Migrations
{
    [DbContext(typeof(DiscussionContext))]
    [Migration("20190409104945_AddParticipants")]
    partial class AddParticipants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Attachments.Attachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("DiscussionId");

                    b.Property<long?>("ResponseId");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("ResponseId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Discussion", b =>
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

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Participant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DiscussionId");

                    b.Property<long>("EntityId");

                    b.Property<int>("EntityType");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Responses.Response", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("DiscussionId");

                    b.Property<long?>("DocumentId");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("UserId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Attachments.Attachment", b =>
                {
                    b.HasOne("Emsa.Mared.Discussions.API.Database.Repositories.Discussion")
                        .WithMany("Attachments")
                        .HasForeignKey("DiscussionId");

                    b.HasOne("Emsa.Mared.Discussions.API.Database.Repositories.Responses.Response")
                        .WithMany("Attachments")
                        .HasForeignKey("ResponseId");
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Participant", b =>
                {
                    b.HasOne("Emsa.Mared.Discussions.API.Database.Repositories.Discussion", "Discussion")
                        .WithMany("Participants")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Emsa.Mared.Discussions.API.Database.Repositories.Responses.Response", b =>
                {
                    b.HasOne("Emsa.Mared.Discussions.API.Database.Repositories.Discussion", "Discussion")
                        .WithMany("Responses")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Emsa.Mared.Discussions.API.Database.Repositories.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
