using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni_E_Commerce_Service.Migrations
{
    /// <inheritdoc />
    public partial class init_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsCartItemsOfOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    CartItemsId = table.Column<int>(type: "int", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCartItemsOfOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsCartItemsOfOrders_CartItems_CartItemsId",
                        column: x => x.CartItemsId,
                        principalTable: "CartItems",
                        principalColumn: "CartItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCartItemsOfOrders_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCartItemsOfOrders_CartItemsId",
                table: "ProductsCartItemsOfOrders",
                column: "CartItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCartItemsOfOrders_ProductsId",
                table: "ProductsCartItemsOfOrders",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsCartItemsOfOrders");
        }
    }
}
