using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raja_Country_Api.Migrations
{
    /// <inheritdoc />
    public partial class new5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictDetails_StateDetails_StateId",
                table: "DistrictDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StateDetails_CountryDetails_CountryId",
                table: "StateDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "StateDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "DistrictDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictDetails_StateDetails_StateId",
                table: "DistrictDetails",
                column: "StateId",
                principalTable: "StateDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StateDetails_CountryDetails_CountryId",
                table: "StateDetails",
                column: "CountryId",
                principalTable: "CountryDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictDetails_StateDetails_StateId",
                table: "DistrictDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StateDetails_CountryDetails_CountryId",
                table: "StateDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "StateDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "DistrictDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictDetails_StateDetails_StateId",
                table: "DistrictDetails",
                column: "StateId",
                principalTable: "StateDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateDetails_CountryDetails_CountryId",
                table: "StateDetails",
                column: "CountryId",
                principalTable: "CountryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
