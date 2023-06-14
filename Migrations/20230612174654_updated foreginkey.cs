using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace On_Demand_Car_Wash_ApiV2.Migrations
{
    /// <inheritdoc />
    public partial class updatedforeginkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserDetails_CustId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustId",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustId",
                table: "Addresses",
                column: "CustId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserDetails_CustId",
                table: "Addresses",
                column: "CustId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
