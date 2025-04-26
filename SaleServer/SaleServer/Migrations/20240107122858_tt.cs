using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleServer.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donor_donorId",
                table: "Gifts",
                column: "donorId",
                principalTable: "Donor",
                principalColumn: "Id");
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
    }
}
