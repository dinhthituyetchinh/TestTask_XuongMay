using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XuongMayBE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "ProductionLines",
               columns: table => new
               {
                   LineID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   LineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   WorkerCount = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ProductionLines", x => x.LineID);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
            migrationBuilder.DropTable(
                name: "ProductionLines");
        }
    }
}
