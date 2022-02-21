using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class AddCategoriaDespesaOnDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "categoriaId",
                table: "despesa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_despesa_categoriaId",
                table: "despesa",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_despesa_categoria_categoriaId",
                table: "despesa",
                column: "categoriaId",
                principalTable: "categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_despesa_categoria_categoriaId",
                table: "despesa");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropIndex(
                name: "IX_despesa_categoriaId",
                table: "despesa");

            migrationBuilder.DropColumn(
                name: "categoriaId",
                table: "despesa");
        }
    }
}
