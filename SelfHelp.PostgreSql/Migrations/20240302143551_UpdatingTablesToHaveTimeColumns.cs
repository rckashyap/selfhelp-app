using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfHelp.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTablesToHaveTimeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "self_help",
                table: "user",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "self_help",
                table: "challenge",
                newName: "ModifiedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "self_help",
                table: "challenge_step",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "self_help",
                table: "challenge_step",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "self_help",
                table: "challenge_step");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "self_help",
                table: "challenge_step");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                schema: "self_help",
                table: "user",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                schema: "self_help",
                table: "challenge",
                newName: "UpdatedOn");
        }
    }
}
