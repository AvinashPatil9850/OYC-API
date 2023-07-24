using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OYC_API.Migrations
{
    /// <inheritdoc />
    public partial class productsize3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeTable_Product_ProductID",
                table: "ProductSizeTable");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizeTable_ProductID",
                table: "ProductSizeTable");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductSizeTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProductSizeTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeTable_ProductID",
                table: "ProductSizeTable",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeTable_Product_ProductID",
                table: "ProductSizeTable",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");
        }
    }
}
