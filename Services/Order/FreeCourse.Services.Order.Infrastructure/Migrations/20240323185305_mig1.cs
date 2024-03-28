using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeCourse.Services.Order.Infrastructure.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress_ZipCode",
                schema: "ordering",
                table: "Orders",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Adress_Street",
                schema: "ordering",
                table: "Orders",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Adress_Province",
                schema: "ordering",
                table: "Orders",
                newName: "Address_Province");

            migrationBuilder.RenameColumn(
                name: "Adress_Line",
                schema: "ordering",
                table: "Orders",
                newName: "Address_Line");

            migrationBuilder.RenameColumn(
                name: "Adress_District",
                schema: "ordering",
                table: "Orders",
                newName: "Address_District");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                schema: "ordering",
                table: "Orders",
                newName: "Adress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                schema: "ordering",
                table: "Orders",
                newName: "Adress_Street");

            migrationBuilder.RenameColumn(
                name: "Address_Province",
                schema: "ordering",
                table: "Orders",
                newName: "Adress_Province");

            migrationBuilder.RenameColumn(
                name: "Address_Line",
                schema: "ordering",
                table: "Orders",
                newName: "Adress_Line");

            migrationBuilder.RenameColumn(
                name: "Address_District",
                schema: "ordering",
                table: "Orders",
                newName: "Adress_District");
        }
    }
}
