using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb_Farrwest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    width = table.Column<int>(type: "int", nullable: false),
                    depth = table.Column<int>(type: "int", nullable: false),
                    numOfDrawers = table.Column<int>(type: "int", nullable: false),
                    desktopMaterial = table.Column<int>(type: "int", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deliveryOptions = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    dateDisplayString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quoteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}
