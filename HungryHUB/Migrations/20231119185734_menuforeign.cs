using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHUB.Migrations
{
    public partial class menuforeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityID",
                table: "DeliverPartners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverPartners_CityID",
                table: "DeliverPartners",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliverPartners_Cities_CityID",
                table: "DeliverPartners",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliverPartners_Cities_CityID",
                table: "DeliverPartners");

            migrationBuilder.DropIndex(
                name: "IX_DeliverPartners_CityID",
                table: "DeliverPartners");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "DeliverPartners");
        }
    }
}
