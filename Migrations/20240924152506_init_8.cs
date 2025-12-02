using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni_E_Commerce_Service.Migrations
{
    /// <inheritdoc />
    public partial class init_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
               name: "ApplyCoupon",
               table: "Orders",
               type: "bit",
               nullable: false,
               defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
              name: "ApplyCoupon",
              table: "Orders",
              type: "bit",
              nullable: false,
              defaultValue: false);
        }
    }
}
