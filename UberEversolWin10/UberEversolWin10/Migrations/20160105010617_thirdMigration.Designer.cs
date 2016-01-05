using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using UberEversol.Model;

namespace UberEversol.Migrations
{
    [DbContext(typeof(UberEversolContext))]
    [Migration("20160105010617_thirdMigration")]
    partial class thirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("UberEversol.Model.MediaType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<int>("index");

                    b.Property<string>("title")
                        .IsRequired();

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.Model.Session", b =>
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

            modelBuilder.Entity("UberEversol.Model.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Trackid");

                    b.Property<bool>("active");

                    b.Property<DateTime>("created");

                    b.Property<DateTime?>("dob");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("hit_count");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("recording_count");

                    b.Property<int>("user_rating");

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.Model.Track", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_date");

                    b.Property<string>("description");

                    b.Property<TimeSpan?>("duration");

                    b.Property<string>("file_dir");

                    b.Property<string>("file_name");

                    b.Property<int>("file_size");

                    b.Property<int>("index");

                    b.Property<string>("keywords");

                    b.Property<int>("session_id");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.Models.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("id");
                });

            modelBuilder.Entity("UberEversol.Model.Subject", b =>
                {
                    b.HasOne("UberEversol.Model.Track")
                        .WithMany()
                        .HasForeignKey("Trackid");
                });

            modelBuilder.Entity("UberEversol.Model.Track", b =>
                {
                    b.HasOne("UberEversol.Model.Session")
                        .WithMany()
                        .HasForeignKey("session_id");
                });
        }
    }
}
