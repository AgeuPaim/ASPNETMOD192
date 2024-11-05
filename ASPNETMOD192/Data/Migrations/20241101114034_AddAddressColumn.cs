using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETMOD192.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "Staff",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "Clients",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Staff",
                newName: "Addres");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "Addres");
        }
    }
}
