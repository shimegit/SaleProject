using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleServer.Migrations
{
    /// <inheritdoc />
    public partial class chek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donor_donorId",
                table: "Gifts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "donorId",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donor_donorId",
                table: "Gifts",
                column: "donorId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donor_donorId",
                table: "Gifts");

            migrationBuilder.AlterColumn<int>(
                name: "donorId",
                table: "Gifts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GiftId",
                table: "OrderDetails",
                column: "GiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donor_donorId",
                table: "Gifts",
                column: "donorId",
                principalTable: "Donor",
                principalColumn: "Id");
        }
    }
}
