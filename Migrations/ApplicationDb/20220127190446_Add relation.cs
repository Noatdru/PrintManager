using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintManager.Migrations.ApplicationDb
{
    public partial class Addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PrintQueueElements_PrinterId",
                table: "PrintQueueElements",
                column: "PrinterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintQueueElements_Device_PrinterId",
                table: "PrintQueueElements",
                column: "PrinterId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrintQueueElements_Device_PrinterId",
                table: "PrintQueueElements");

            migrationBuilder.DropIndex(
                name: "IX_PrintQueueElements_PrinterId",
                table: "PrintQueueElements");
        }
    }
}
