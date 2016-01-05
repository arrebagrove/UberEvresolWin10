using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace UberEversol.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "FirstName", table: "Subject");
            migrationBuilder.DropColumn(name: "FullName", table: "Subject");
            migrationBuilder.DropColumn(name: "LastName", table: "Subject");
            migrationBuilder.DropColumn(name: "Rating", table: "Subject");
            migrationBuilder.DropColumn(name: "Date", table: "Session");
            migrationBuilder.DropColumn(name: "FolderDirectory", table: "Session");
            migrationBuilder.AddColumn<int>(
                name: "Trackid",
                table: "Subject",
                nullable: true);
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "Subject",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "Subject",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "Subject",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<int>(
                name: "hit_count",
                table: "Subject",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "Subject",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<int>(
                name: "recording_count",
                table: "Subject",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "user_rating",
                table: "Subject",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Track",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Track",
                nullable: true);
            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                table: "Track",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "file_dir",
                table: "Track",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "file_name",
                table: "Track",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "file_size",
                table: "Track",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "index",
                table: "Track",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "keywords",
                table: "Track",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "session_id",
                table: "Track",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Track",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Session",
                nullable: false);
            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Session",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "folderDir",
                table: "Session",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "hit_count",
                table: "Session",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "MediaType",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "index",
                table: "MediaType",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "MediaType",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Track_Trackid",
                table: "Subject",
                column: "Trackid",
                principalTable: "Track",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Track_Session_session_id",
                table: "Track",
                column: "session_id",
                principalTable: "Session",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Subject",
                newName: "created");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subject",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Session",
                newName: "title");
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Session",
                newName: "description");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Session",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Subject_Track_Trackid", table: "Subject");
            migrationBuilder.DropForeignKey(name: "FK_Track_Session_session_id", table: "Track");
            migrationBuilder.DropColumn(name: "created_date", table: "Track");
            migrationBuilder.DropColumn(name: "description", table: "Track");
            migrationBuilder.DropColumn(name: "duration", table: "Track");
            migrationBuilder.DropColumn(name: "file_dir", table: "Track");
            migrationBuilder.DropColumn(name: "file_name", table: "Track");
            migrationBuilder.DropColumn(name: "file_size", table: "Track");
            migrationBuilder.DropColumn(name: "index", table: "Track");
            migrationBuilder.DropColumn(name: "keywords", table: "Track");
            migrationBuilder.DropColumn(name: "session_id", table: "Track");
            migrationBuilder.DropColumn(name: "title", table: "Track");
            migrationBuilder.DropColumn(name: "Trackid", table: "Subject");
            migrationBuilder.DropColumn(name: "active", table: "Subject");
            migrationBuilder.DropColumn(name: "dob", table: "Subject");
            migrationBuilder.DropColumn(name: "first_name", table: "Subject");
            migrationBuilder.DropColumn(name: "hit_count", table: "Subject");
            migrationBuilder.DropColumn(name: "last_name", table: "Subject");
            migrationBuilder.DropColumn(name: "recording_count", table: "Subject");
            migrationBuilder.DropColumn(name: "user_rating", table: "Subject");
            migrationBuilder.DropColumn(name: "created", table: "Session");
            migrationBuilder.DropColumn(name: "folderDir", table: "Session");
            migrationBuilder.DropColumn(name: "hit_count", table: "Session");
            migrationBuilder.DropColumn(name: "description", table: "MediaType");
            migrationBuilder.DropColumn(name: "index", table: "MediaType");
            migrationBuilder.DropColumn(name: "title", table: "MediaType");
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Subject",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Subject",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Subject",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Subject",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Session",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Session",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "FolderDirectory",
                table: "Session",
                nullable: true);
            migrationBuilder.RenameColumn(
                name: "created",
                table: "Subject",
                newName: "Created");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Subject",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Session",
                newName: "Title");
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Session",
                newName: "Description");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Session",
                newName: "Id");
        }
    }
}
