using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raja_Country_Api.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateDetails_CountryDetails_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DistrictDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistrictDetails_StateDetails_StateId",
                        column: x => x.StateId,
                        principalTable: "StateDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryDetails_Name",
                table: "CountryDetails",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictDetails_Name",
                table: "DistrictDetails",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictDetails_StateId",
                table: "DistrictDetails",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_StateDetails_CountryId",
                table: "StateDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StateDetails_Name",
                table: "StateDetails",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistrictDetails");

            migrationBuilder.DropTable(
                name: "LocationDetails");

            migrationBuilder.DropTable(
                name: "StateDetails");

            migrationBuilder.DropTable(
                name: "CountryDetails");
        }
    }
}
