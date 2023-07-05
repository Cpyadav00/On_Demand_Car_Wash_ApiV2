using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace On_Demand_Car_Wash_ApiV2.Migrations
{
    /// <inheritdoc />
    public partial class addedgenderagepermanentAddressinuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParmanentAddress",
                table: "UserDetails",
                newName: "PermanentAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermanentAddress",
                table: "UserDetails",
                newName: "ParmanentAddress");
        }
    }
}
