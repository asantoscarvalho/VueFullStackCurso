using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetcSchool_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id", "Nome" },
                values: new object[] { 1, "Ligia" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "id", "Nome" },
                values: new object[] { 2, "Andre" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id", "DataNascimento", "Nome", "ProfessorId", "SobreNome" },
                values: new object[] { 1, "26/03/2009", "João", 1, "Margotto" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id", "DataNascimento", "Nome", "ProfessorId", "SobreNome" },
                values: new object[] { 3, "16/12/2016", "Joaquim", 1, "Margotto" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "id", "DataNascimento", "Nome", "ProfessorId", "SobreNome" },
                values: new object[] { 2, "16/11/2009", "Pedro", 2, "Margotto" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
