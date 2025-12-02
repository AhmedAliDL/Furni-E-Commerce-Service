using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni_E_Commerce_Service.Migrations
{
    /// <inheritdoc />
    public partial class init_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(120)",
                nullable: false,
                defaultValue: "Unknown");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "Unknown");

            migrationBuilder.AddColumn<int>(
                name: "ExpirationMonth",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationYear",
                table: "AspNetUsers",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "AspNetUsers",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "AspNetUsers",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.DropColumn(
               name: "Expiration",
               table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "Country",
              table: "AspNetUsers",
              type: "nvarchar(120)",
              nullable: false,
              defaultValue: "Unknown");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "Unknown");

            migrationBuilder.AddColumn<int>(
                name: "ExpirationMonth",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
            migrationBuilder.AddColumn<string>(
              name: "ExpirationYear",
              table: "AspNetUsers",
              type: "nvarchar(2)",
              nullable: true);
           
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CVV",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);
            migrationBuilder.DropColumn(
               name: "Expiration",
               table: "AspNetUsers");

        }
    }
}
