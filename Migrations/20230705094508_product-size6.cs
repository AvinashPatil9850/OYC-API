using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OYC_API.Migrations
{
    /// <inheritdoc />
    public partial class productsize6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeTable_Product_ProductID",
                table: "ProductSizeTable");

            migrationBuilder.RenameColumn(
                name: "ProductSizeID",
                table: "ProductSizeTable",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductSizeTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeTable_Product_ProductID",
                table: "ProductSizeTable",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizeTable_Product_ProductID",
                table: "ProductSizeTable");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProductSizeTable",
                newName: "ProductSizeID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductSizeTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizeTable_Product_ProductID",
                table: "ProductSizeTable",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");
        }
    }
}
