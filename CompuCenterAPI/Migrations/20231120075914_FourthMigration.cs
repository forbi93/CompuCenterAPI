using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompuCenterAPI.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "ClienteIdCliente",
                table: "Ventas",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClienteIdCliente",
                table: "Ventas",
                newName: "IX_Ventas_ClienteId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProducto",
                table: "DetallesVentas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "DetallesVentas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "DetallesVentas");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "DetallesVentas");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Ventas",
                newName: "ClienteIdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                newName: "IX_Ventas_ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteIdCliente",
                table: "Ventas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
