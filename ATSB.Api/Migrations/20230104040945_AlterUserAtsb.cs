using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATSB.Migrations
{
    public partial class AlterUserAtsb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoEmpresa",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoEmpresa",
                table: "AspNetUsers");
        }
    }
}
