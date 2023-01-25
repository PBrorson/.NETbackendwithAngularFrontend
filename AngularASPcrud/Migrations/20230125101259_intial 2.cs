using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularASPcrud.Migrations
{
    /// <inheritdoc />
    public partial class intial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Students",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Students",
                newName: "firstname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Students",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Students",
                newName: "firstName");
        }
    }
}
