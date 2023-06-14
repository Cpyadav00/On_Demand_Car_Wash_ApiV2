using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace On_Demand_Car_Wash_ApiV2.Migrations
{
    /// <inheritdoc />
    public partial class updatedordermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Packages_PackageId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserDetails_CustId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PackageId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustId",
                table: "Orders",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackageId",
                table: "Orders",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Packages_PackageId",
                table: "Orders",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserDetails_CustId",
                table: "Orders",
                column: "CustId",
                principalTable: "UserDetails",
                principalColumn: "UserId");
        }
    }
}
