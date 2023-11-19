using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHUB.Migrations
{
    public partial class delivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliverPartners",
                columns: table => new
                {
                    DeliveryPartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverPartners", x => x.DeliveryPartnerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliverPartners");
        }
    }
}
