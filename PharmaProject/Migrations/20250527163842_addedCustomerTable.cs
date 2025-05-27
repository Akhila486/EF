using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaProject.Migrations
{
    /// <inheritdoc />
    public partial class addedCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_CustomerID",
                table: "Medicines",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Customers_CustomerID",
                table: "Medicines",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Customers_CustomerID",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_CustomerID",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Medicines");
        }
    }
}
