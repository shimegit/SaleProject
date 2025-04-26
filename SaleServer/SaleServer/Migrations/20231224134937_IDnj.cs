//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace SaleServer.Migrations
//{
//    /// <inheritdoc />
//    public partial class IDnj : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Donor",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Donor", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "User",
//                columns: table => new
//                {
//                    UserId = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_User", x => x.UserId);
//                });

//            migrationBuilder.CreateTable(
//                name: "Gifts",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    ticketPrice = table.Column<int>(type: "int", nullable: false),
//                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    donorId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Gifts", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Gifts_Donor_donorId",
//                        column: x => x.donorId,
//                        principalTable: "Donor",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Order",
//                columns: table => new
//                {
//                    OrderId = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    userId = table.Column<int>(type: "int", nullable: false),
//                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Order", x => x.OrderId);
//                    table.ForeignKey(
//                        name: "FK_Order_User_userId",
//                        column: x => x.userId,
//                        principalTable: "User",
//                        principalColumn: "UserId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "OrderDetails",
//                columns: table => new
//                {
//                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    GiftId = table.Column<int>(type: "int", nullable: false),
//                    Quantity = table.Column<int>(type: "int", nullable: false),
//                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    OrderId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsId);
//                    table.ForeignKey(
//                        name: "FK_OrderDetails_Gifts_GiftId",
//                        column: x => x.GiftId,
//                        principalTable: "Gifts",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_OrderDetails_Order_OrderId",
//                        column: x => x.OrderId,
//                        principalTable: "Order",
//                        principalColumn: "OrderId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Gifts_donorId",
//                table: "Gifts",
//                column: "donorId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Order_userId",
//                table: "Order",
//                column: "userId");

//            migrationBuilder.CreateIndex(
//                name: "IX_OrderDetails_GiftId",
//                table: "OrderDetails",
//                column: "GiftId");

//            migrationBuilder.CreateIndex(
//                name: "IX_OrderDetails_OrderId",
//                table: "OrderDetails",
//                column: "OrderId");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "OrderDetails");

//            migrationBuilder.DropTable(
//                name: "Gifts");

//            migrationBuilder.DropTable(
//                name: "Order");

//            migrationBuilder.DropTable(
//                name: "Donor");

//            migrationBuilder.DropTable(
//                name: "User");
//        }
//    }
//}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleServer.Migrations
{
    /// <inheritdoc />
    public partial class IDnj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketPrice = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gifts_Donor_donorId",
                        column: x => x.donorId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Set cascade delete behavior
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_donorId",
                table: "Gifts",
                column: "donorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GiftId",
                table: "OrderDetails",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}