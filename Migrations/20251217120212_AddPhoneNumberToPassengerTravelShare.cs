using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfLearning.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberToPassengerTravelShare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "passenger_travel_share",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "passenger_travel_share");
        }
    }
}
