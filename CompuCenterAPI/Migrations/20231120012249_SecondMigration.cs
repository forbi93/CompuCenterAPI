using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompuCenterAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteVenta");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteIdCliente",
                table: "Ventas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Stock",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteIdCliente",
                table: "Ventas",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteIdCliente",
                table: "Ventas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "ClienteVenta",
                columns: table => new
                {
                    ClientesIdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentasIdVenta = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteVenta", x => new { x.ClientesIdCliente, x.VentasIdVenta });
                    table.ForeignKey(
                        name: "FK_ClienteVenta_Clientes_ClientesIdCliente",
                        column: x => x.ClientesIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteVenta_Ventas_VentasIdVenta",
                        column: x => x.VentasIdVenta,
                        principalTable: "Ventas",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteVenta_VentasIdVenta",
                table: "ClienteVenta",
                column: "VentasIdVenta");
        }
    }
}
