using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGerenciadorDeTransportes.Migrations
{
    /// <inheritdoc />
    public partial class Migracao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificacao",
                table: "tb_veiculo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificacao",
                table: "tb_veiculo");
        }
    }
}
