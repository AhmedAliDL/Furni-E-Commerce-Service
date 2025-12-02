using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni_E_Commerce_Service.Migrations
{
    /// <inheritdoc />
    public partial class init_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpirationMonth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpirationYear",
                table: "AspNetUsers");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "AspNetUsers",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "AspNetUsers",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpirationMonth",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationYear",
                table: "AspNetUsers",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);
        }
    }
}
