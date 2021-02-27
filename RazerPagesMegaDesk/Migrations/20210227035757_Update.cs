using Microsoft.EntityFrameworkCore.Migrations;

namespace RazerPagesMegaDesk.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_SurfaceMaterial_SurfaceMaterialId",
                table: "Desk");

            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Shipping_ShippingId",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingId",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurfaceMaterialId",
                table: "Desk",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_SurfaceMaterial_SurfaceMaterialId",
                table: "Desk",
                column: "SurfaceMaterialId",
                principalTable: "SurfaceMaterial",
                principalColumn: "SurfaceMaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Shipping_ShippingId",
                table: "DeskQuote",
                column: "ShippingId",
                principalTable: "Shipping",
                principalColumn: "ShippingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_SurfaceMaterial_SurfaceMaterialId",
                table: "Desk");

            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Shipping_ShippingId",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingId",
                table: "DeskQuote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SurfaceMaterialId",
                table: "Desk",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_SurfaceMaterial_SurfaceMaterialId",
                table: "Desk",
                column: "SurfaceMaterialId",
                principalTable: "SurfaceMaterial",
                principalColumn: "SurfaceMaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Shipping_ShippingId",
                table: "DeskQuote",
                column: "ShippingId",
                principalTable: "Shipping",
                principalColumn: "ShippingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
