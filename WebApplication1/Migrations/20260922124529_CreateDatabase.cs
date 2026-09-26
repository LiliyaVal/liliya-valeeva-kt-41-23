using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace liliyavaleevaKt_41_23.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    is_deleted = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cd_discipline", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_specialty",
                columns: table => new
                {
                    specialty_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    code = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cd_specialty", x => x.specialty_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    course = table.Column<int>(type: "int4", nullable: false),
                    specialty_id = table.Column<int>(type: "int4", nullable: false),
                    is_deleted = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cd_group", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_cd_group_cd_specialty_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "cd_specialty",
                        principalColumn: "specialty_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    group_id = table.Column<int>(type: "int4", nullable: false),
                    is_deleted = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cd_student", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_cd_student_cd_group_group_id",
                        column: x => x.group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<int>(type: "int4", nullable: false),
                    student_id = table.Column<int>(type: "int4", nullable: false),
                    discipline_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cd_grade", x => x.grade_id);
                    table.ForeignKey(
                        name: "FK_cd_grade_cd_discipline_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cd_grade_cd_student_student_id",
                        column: x => x.student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_discipline_id",
                table: "cd_grade",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_student_id",
                table: "cd_grade",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_group_specialty_id",
                table: "cd_group",
                column: "specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_student_group_id",
                table: "cd_student",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_grade");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");

            migrationBuilder.DropTable(
                name: "cd_specialty");
        }
    }
}
