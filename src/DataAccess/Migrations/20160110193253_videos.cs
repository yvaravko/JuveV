using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace DataAccess.Migrations
{
    public partial class videos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Team_Country_CountryId", table: "Team");
            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VideoExerpt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.VideoId);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Team_Country_CountryId",
                table: "Team",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Team_Country_CountryId", table: "Team");
            migrationBuilder.DropTable("Video");
            migrationBuilder.AddForeignKey(
                name: "FK_Team_Country_CountryId",
                table: "Team",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
