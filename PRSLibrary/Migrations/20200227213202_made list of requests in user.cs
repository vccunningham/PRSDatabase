using Microsoft.EntityFrameworkCore.Migrations;

namespace PRSLibrary.Migrations
{
    public partial class madelistofrequestsinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Products",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ProductId",
                table: "Vendors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Products_ProductId",
                table: "Vendors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Products_ProductId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_ProductId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UserId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Vendors");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
