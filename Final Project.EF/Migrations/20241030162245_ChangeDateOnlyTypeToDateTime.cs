using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateOnlyTypeToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event_Start_Date",
                table: "News");

            migrationBuilder.AddColumn<DateTime>(
                name: "News_Date",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Event_Start_Date",
                table: "Events",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "News_Date",
                table: "News");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Event_Start_Date",
                table: "News",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Event_Start_Date",
                table: "Events",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
