using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OYC_API.Migrations
{
    /// <inheritdoc />
    public partial class productsize2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSizeTable",
                columns: table => new
                {
                    ProductSizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizeTable", x => x.ProductSizeID);
                    table.ForeignKey(
                        name: "FK_ProductSizeTable_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeTable_ProductID",
                table: "ProductSizeTable",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSizeTable");
        }
    }
}
