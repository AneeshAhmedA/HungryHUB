using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHUB.Migrations
{
    public partial class del : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliverPartners_Cities_CityID",
                table: "DeliverPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliverPartners",
                table: "DeliverPartners");

            migrationBuilder.RenameTable(
                name: "DeliverPartners",
                newName: "DeliveryPartners");

            migrationBuilder.RenameIndex(
                name: "IX_DeliverPartners_CityID",
                table: "DeliveryPartners",
                newName: "IX_DeliveryPartners_CityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryPartners",
                table: "DeliveryPartners",
                column: "DeliveryPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryPartners_Cities_CityID",
                table: "DeliveryPartners",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryPartners_Cities_CityID",
                table: "DeliveryPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryPartners",
                table: "DeliveryPartners");

            migrationBuilder.RenameTable(
                name: "DeliveryPartners",
                newName: "DeliverPartners");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryPartners_CityID",
                table: "DeliverPartners",
                newName: "IX_DeliverPartners_CityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliverPartners",
                table: "DeliverPartners",
                column: "DeliveryPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliverPartners_Cities_CityID",
                table: "DeliverPartners",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
