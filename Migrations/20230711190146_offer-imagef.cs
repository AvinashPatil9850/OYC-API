using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OYC_API.Migrations
{
    /// <inheritdoc />
    public partial class offerimagef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSrc",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductSrc",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
