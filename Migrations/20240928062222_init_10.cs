using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni_E_Commerce_Service.Migrations
{
    /// <inheritdoc />
    public partial class init_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsCartItemsOfOrders");

            migrationBuilder.DropColumn(
                name: "ApplyCoupon",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "CouponDiscount",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponDiscount",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "ApplyCoupon",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProductsCartItemsOfOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
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
    }
}
