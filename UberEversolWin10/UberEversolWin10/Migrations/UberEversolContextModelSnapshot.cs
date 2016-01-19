using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using UberEversol.DataModel;

namespace UberEversol.Migrations
{
    [DbContext(typeof(UberEversolContext))]
    partial class UberEversolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("UberEversol.DataModel.MediaRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("completed");

                    b.Property<DateTime>("completed_date");

                    b.Property<string>("email");

                    b.Property<int?>("mediaid")
                        .IsRequired();

                    b.Property<string>("notes");

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<DateTime>("request_date");

                    b.Property<int?>("requestorid")
                        .IsRequired();

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.MediaType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<int>("index");

                    b.Property<string>("title")
                        .IsRequired();

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.Requestee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created");

                    b.Property<DateTime?>("dob");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.Session", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created");

                    b.Property<string>("description")
                        .HasAnnotation("MaxLength", 600);

                    b.Property<string>("folderDir");

                    b.Property<int?>("hit_count");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("active");

                    b.Property<DateTime>("created");

                    b.Property<DateTime?>("dob");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("hit_count");

                    b.Property<byte[]>("image");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("recording_count");

                    b.Property<int>("user_rating");

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.Track", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MediaRequestid");

                    b.Property<DateTime>("created_date");

                    b.Property<string>("description");

                    b.Property<TimeSpan?>("duration");

                    b.Property<string>("file_dir");

                    b.Property<string>("file_name");

                    b.Property<int>("file_size");

                    b.Property<int>("index");

                    b.Property<string>("keywords");

                    b.Property<int>("session_id");

                    b.Property<int>("subject_id");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.TrackSubjects", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("subject_id");

                    b.Property<int>("track_id");

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.DataModel.MediaRequest", b =>
                {
                    b.HasOne("UberEversol.DataModel.MediaType")
                        .WithMany()
                        .HasForeignKey("mediaid");

                    b.HasOne("UberEversol.DataModel.Requestee")
                        .WithMany()
                        .HasForeignKey("requestorid");
                });

            modelBuilder.Entity("UberEversol.DataModel.Track", b =>
                {
                    b.HasOne("UberEversol.DataModel.MediaRequest")
                        .WithMany()
                        .HasForeignKey("MediaRequestid");

                    b.HasOne("UberEversol.DataModel.Session")
                        .WithMany()
                        .HasForeignKey("session_id");

                    b.HasOne("UberEversol.DataModel.Subject")
                        .WithMany()
                        .HasForeignKey("subject_id");
                });
        }
    }
}
