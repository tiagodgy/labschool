using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSchool.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nota = table.Column<float>(type: "real", nullable: true),
                    Atendimentos = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Pedagogos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atendimentos = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagogos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Codigo);
                });
            migrationBuilder.Sql("INSERT INTO Alunos (Nome, Telefone, DataNascimento, Cpf, Situacao, Nota, Atendimentos) VALUES ('Bart Simpson', '11-11111-1212', '2014-10-29', 11839750073, 'IRREGULAR', 3.5, 0), ('Lisa Simpson', '11-22222-2222', '2012-10-29', 17158947076, 'ATIVO', 10, 0), ('Meggie Simpson', '12-20002-2200', '2019-10-29', 63701210020, 'ATIVO', 9, 0), ('Milhouse Van Houten', '11-33333-2222', '2014-10-29', 30119137062, 'ATIVO', 8, 0), ('Nelson Muntz', '11-44333-4444', '2007-10-29', 95704094015, 'INATIVO', 2, 0)");
            migrationBuilder.Sql("INSERT INTO Professores (Nome, Telefone, DataNascimento, Cpf, Estado, Experiencia, Formacao) VALUES ('Walter White', '14-22998-1882', '1982-10-30', 40539019011, 'ATIVO', 'FULL_STACK', 'MESTRADO'), ('Jesse Pinkman', '44-11111-1992', '1997-10-30', 96107295097, 'ATIVO', 'BACK_END', 'GRADUACAO_INCOMPLETA'), ('Hank Schrader', '44-11111-1002', '1984-10-30', 70685977005, 'ATIVO', 'FULL_STACK', 'MESTRADO'), ('Gustavo Fring', '44-11001-1002', '1997-10-30', 57408927085, 'INATIVO', 'FRONT_END', 'GRADUACAO_COMPLETA'), ('Saul GoodMan', '44-11998-1882', '1980-10-30', 86940162062, 'ATIVO', 'FULL_STACK', 'MESTRADO')");
            migrationBuilder.Sql("INSERT INTO Pedagogos (Nome, Telefone, DataNascimento, Cpf, Atendimentos) VALUES ('John Snow ', '11-67333-4454', '2000-10-30', 62316840086, 0), ('Sansa Stark', '22-22333-4454', '2004-10-30', 49850253053, 0), ('Tyrion Lannister', '33-77333-4454', '1990-10-30', 39125106015, 0), ('Sandor Clegane', '11-33333-2222', '1995-10-30', 89089606009, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Pedagogos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
