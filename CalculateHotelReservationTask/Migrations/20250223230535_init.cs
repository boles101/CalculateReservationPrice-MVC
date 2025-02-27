using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculateHotelReservationTask.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mealPlans",
                columns: table => new
                {
                    MealPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealPlans", x => x.MealPlanId);
                });

            migrationBuilder.CreateTable(
                name: "roomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "mealPlanRates",
                columns: table => new
                {
                    MealPlanRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealPlanId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealPlanRates", x => x.MealPlanRateId);
                    table.ForeignKey(
                        name: "FK_mealPlanRates_mealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "mealPlans",
                        principalColumn: "MealPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roomRates",
                columns: table => new
                {
                    RoomRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomRates", x => x.RoomRateId);
                    table.ForeignKey(
                        name: "FK_roomRates_roomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "roomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mealPlanRates_MealPlanId",
                table: "mealPlanRates",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_roomRates_RoomTypeId",
                table: "roomRates",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mealPlanRates");

            migrationBuilder.DropTable(
                name: "roomRates");

            migrationBuilder.DropTable(
                name: "mealPlans");

            migrationBuilder.DropTable(
                name: "roomTypes");
        }
    }
}
