using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHUB.Migrations
{
    public partial class foreign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RestaurantId",
                table: "MenuItem",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Restaurants_RestaurantId",
                table: "MenuItem",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Restaurants_RestaurantId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_RestaurantId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "MenuItem");
        }
    }
}
