using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroWebVendedores_Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AjusteIntegridadeReferencialVendedorVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroDeVendas_Vendedor_VendedorId",
                table: "RegistroDeVendas");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDeVenda",
                table: "RegistroDeVendas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroDeVendas_Vendedor_VendedorId",
                table: "RegistroDeVendas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroDeVendas_Vendedor_VendedorId",
                table: "RegistroDeVendas");

            migrationBuilder.AlterColumn<double>(
                name: "ValorDeVenda",
                table: "RegistroDeVendas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroDeVendas_Vendedor_VendedorId",
                table: "RegistroDeVendas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
