using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarStore.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model = table.Column<string>(type: "text", nullable: false),
                    horsepowers = table.Column<int>(name: "horse_powers", type: "integer", nullable: false),
                    enginevolume = table.Column<double>(name: "engine_volume", type: "double precision", nullable: false),
                    colors = table.Column<string>(type: "text", nullable: false),
                    releaseyear = table.Column<int>(name: "release_year", type: "integer", nullable: false),
                    doorscount = table.Column<int>(name: "doors_count", type: "integer", nullable: false),
                    imageids = table.Column<long[]>(name: "image_ids", type: "bigint[]", nullable: false),
                    startprice = table.Column<int>(name: "start_price", type: "integer", nullable: false),
                    companyid = table.Column<long>(name: "company_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<byte[]>(type: "bytea", nullable: false),
                    ImageIds = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_images_cars_ImageIds",
                        column: x => x.ImageIds,
                        principalTable: "cars",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    logopictureid = table.Column<long>(name: "logo_picture_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_images_logo_picture_id",
                        column: x => x.logopictureid,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_company_id",
                table: "cars",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_logo_picture_id",
                table: "companies",
                column: "logo_picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_images_ImageIds",
                table: "images",
                column: "ImageIds");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_companies_company_id",
                table: "cars",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_companies_company_id",
                table: "cars");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "cars");
        }
    }
}
