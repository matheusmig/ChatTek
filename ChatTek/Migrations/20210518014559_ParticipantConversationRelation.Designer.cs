﻿// <auto-generated />
using System;
using ChatTek.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatTek.Migrations
{
    [DbContext(typeof(ChattekDbContext))]
    [Migration("20210518014559_ParticipantConversationRelation")]
    partial class ParticipantConversationRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("ChatTek.Models.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("ChatTek.Models.MessageText", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<Guid>("SenderUserId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("SentOn")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TargetConversationId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatTek.Models.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("LastName")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("ConversationParticipant", b =>
                {
                    b.Property<Guid>("ConversationsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ParticipantsId")
                        .HasColumnType("char(36)");

                    b.HasKey("ConversationsId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("ConversationParticipant");
                });

            modelBuilder.Entity("ConversationParticipant", b =>
                {
                    b.HasOne("ChatTek.Models.Conversation", null)
                        .WithMany()
                        .HasForeignKey("ConversationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatTek.Models.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
