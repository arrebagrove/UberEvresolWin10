using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace UberEversol.Migrations
{
    public partial class migration_base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(nullable: true),
                    index = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.id);
                });
            migrationBuilder.CreateTable(
                name: "Requestee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    created = table.Column<DateTime>(nullable: false),
                    dob = table.Column<DateTime>(nullable: true),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requestee", x => x.id);
                });
            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    created = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    folderDir = table.Column<string>(nullable: true),
                    hit_count = table.Column<int>(nullable: true),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.id);
                });
            migrationBuilder.CreateTable(
                name: "MediaRequest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    completed = table.Column<bool>(nullable: false),
                    completed_date = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    mediaid = table.Column<int>(nullable: false),
                    notes = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: false),
                    request_date = table.Column<DateTime>(nullable: false),
                    requestorid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_MediaRequest_MediaType_mediaid",
                        column: x => x.mediaid,
                        principalTable: "MediaType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRequest_Requestee_requestorid",
                        column: x => x.requestorid,
                        principalTable: "Requestee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaRequestid = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: true),
                    file_dir = table.Column<string>(nullable: true),
                    file_name = table.Column<string>(nullable: true),
                    file_size = table.Column<int>(nullable: false),
                    index = table.Column<int>(nullable: false),
                    keywords = table.Column<string>(nullable: true),
                    session_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.id);
                    table.ForeignKey(
                        name: "FK_Track_MediaRequest_MediaRequestid",
                        column: x => x.MediaRequestid,
                        principalTable: "MediaRequest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Track_Session_session_id",
                        column: x => x.session_id,
                        principalTable: "Session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Trackid = table.Column<int>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    dob = table.Column<DateTime>(nullable: true),
                    first_name = table.Column<string>(nullable: false),
                    hit_count = table.Column<int>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: false),
                    recording_count = table.Column<int>(nullable: false),
                    user_rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subject_Track_Trackid",
                        column: x => x.Trackid,
                        principalTable: "Track",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Subject");
            migrationBuilder.DropTable("Track");
            migrationBuilder.DropTable("MediaRequest");
            migrationBuilder.DropTable("Session");
            migrationBuilder.DropTable("MediaType");
            migrationBuilder.DropTable("Requestee");
        }
    }
}
