using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace dataaccess.Migrations
{
    public partial class PlayerFieldsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Player",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Player",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Player",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Player",
                nullable: true);
        }
    }
}
