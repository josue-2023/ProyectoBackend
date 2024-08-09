using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoPrueba.Migrations
{
    /// <inheritdoc />
    public partial class Productos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Productos");
        }
    }
}
