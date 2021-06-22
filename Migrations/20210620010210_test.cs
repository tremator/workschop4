using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkShop4.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<long>>(
                name: "products_id",
                table: "orders",
                type: "bigint[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "products_id",
                table: "orders");
        }
    }
}
