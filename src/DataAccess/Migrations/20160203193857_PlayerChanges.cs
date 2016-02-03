using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace dataaccess.Migrations
{
    public partial class PlayerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Player",
                nullable: true);
            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Player",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Player",
                nullable: false);
            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Player",
                nullable: false);
        }
    }
}
