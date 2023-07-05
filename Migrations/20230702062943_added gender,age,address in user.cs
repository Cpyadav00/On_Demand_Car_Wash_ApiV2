using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace On_Demand_Car_Wash_ApiV2.Migrations
{
    /// <inheritdoc />
    public partial class addedgenderageaddressinuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParmanentAddress",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "ParmanentAddress",
                table: "UserDetails");
        }
    }
}
