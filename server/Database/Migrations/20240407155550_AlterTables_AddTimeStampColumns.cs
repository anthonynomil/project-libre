using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables_AddTimeStampColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "User",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Quotation",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Quotation",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Invoice",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ClientMissionSpecialRequest",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ClientMissionSpecialRequest",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ClientMissionProject",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ClientMissionProject",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ClientMissionContract",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ClientMissionContract",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ClientMissionCommunication",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ClientMissionCommunication",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ClientMission",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:01'");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ClientMission",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientMissionSpecialRequest");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientMissionSpecialRequest");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientMissionProject");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientMissionProject");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientMissionContract");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientMissionContract");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientMissionCommunication");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientMissionCommunication");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientMission");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientMission");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime",
                oldDefaultValueSql: "'1970-01-01 00:00:01'");
        }
    }
}
