using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp.Infrastructure.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployees_tblTypes_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tblTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tblTypes",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1L, "Department", "Accounts" },
                    { 2L, "Department", "Human resource" },
                    { 3L, "Department", "Document control" },
                    { 4L, "Department", "IT" },
                    { 5L, "Department", "Security" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployees_DepartmentId",
                table: "tblEmployees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmployees");

            migrationBuilder.DropTable(
                name: "tblTypes");
        }
    }
}
