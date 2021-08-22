using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsDisciplines",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDisciplines", x => new { x.StudentId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_StudentsDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsDisciplines_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Lastname", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("ddcd8f2c-6b9c-4a85-b254-6241741f6a28"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kent", "Marta", "33225555", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f58d0279-1ae7-4689-a789-0e58100cca9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabela", "Paula", "3354288", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5394b62e-4e6b-4f85-baa8-4447e3effdfb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonia", "Laura", "55668899", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2153d556-8c74-46fa-a039-e753de73fe6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "Luiza", "6565659", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dbafdeb2-c93f-4b47-b738-4b91e0b59a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Machado", "Lucas", "565685415", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("985b908a-4d24-463a-bc97-ef1e83f3b094"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alvares", "Pedro", "456454545", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51e6da48-4097-4c73-a042-7228c71e3e47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "José", "Paulo", "9874512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("85d9ecd9-91d8-46b3-a25a-1c70509d4942"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lauro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4df4c57-c76c-4fe6-b187-5d7d0b3d88d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85e304e1-cad5-4a64-954a-0b24a50199cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("059773e6-5852-40ec-acd4-275a6badcc6d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodrigo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("faf4e3c5-bd4a-4ef6-9280-2569e8e60b37"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CreatedAt", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("240cf246-08d7-4bc9-988c-8ee543b5ac85"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matemática", new Guid("85d9ecd9-91d8-46b3-a25a-1c70509d4942"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("28641b47-997e-4b67-9819-2a0011e05f87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Física", new Guid("c4df4c57-c76c-4fe6-b187-5d7d0b3d88d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("845305d3-c495-47cd-afb1-692b41b7e11a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Português", new Guid("85e304e1-cad5-4a64-954a-0b24a50199cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5c4d02a-5282-4141-86e7-aec4965210e6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inglês", new Guid("059773e6-5852-40ec-acd4-275a6badcc6d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33cb295e-ba54-4812-8250-d76d7c2b5e03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programação", new Guid("faf4e3c5-bd4a-4ef6-9280-2569e8e60b37"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StudentsDisciplines",
                columns: new[] { "DisciplineId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("240cf246-08d7-4bc9-988c-8ee543b5ac85"), new Guid("f58d0279-1ae7-4689-a789-0e58100cca9a") },
                    { new Guid("33cb295e-ba54-4812-8250-d76d7c2b5e03"), new Guid("f58d0279-1ae7-4689-a789-0e58100cca9a") },
                    { new Guid("33cb295e-ba54-4812-8250-d76d7c2b5e03"), new Guid("ddcd8f2c-6b9c-4a85-b254-6241741f6a28") },
                    { new Guid("e5c4d02a-5282-4141-86e7-aec4965210e6"), new Guid("985b908a-4d24-463a-bc97-ef1e83f3b094") },
                    { new Guid("e5c4d02a-5282-4141-86e7-aec4965210e6"), new Guid("dbafdeb2-c93f-4b47-b738-4b91e0b59a12") },
                    { new Guid("e5c4d02a-5282-4141-86e7-aec4965210e6"), new Guid("2153d556-8c74-46fa-a039-e753de73fe6b") },
                    { new Guid("e5c4d02a-5282-4141-86e7-aec4965210e6"), new Guid("ddcd8f2c-6b9c-4a85-b254-6241741f6a28") },
                    { new Guid("845305d3-c495-47cd-afb1-692b41b7e11a"), new Guid("51e6da48-4097-4c73-a042-7228c71e3e47") },
                    { new Guid("845305d3-c495-47cd-afb1-692b41b7e11a"), new Guid("985b908a-4d24-463a-bc97-ef1e83f3b094") },
                    { new Guid("33cb295e-ba54-4812-8250-d76d7c2b5e03"), new Guid("2153d556-8c74-46fa-a039-e753de73fe6b") },
                    { new Guid("845305d3-c495-47cd-afb1-692b41b7e11a"), new Guid("5394b62e-4e6b-4f85-baa8-4447e3effdfb") },
                    { new Guid("28641b47-997e-4b67-9819-2a0011e05f87"), new Guid("985b908a-4d24-463a-bc97-ef1e83f3b094") },
                    { new Guid("28641b47-997e-4b67-9819-2a0011e05f87"), new Guid("5394b62e-4e6b-4f85-baa8-4447e3effdfb") },
                    { new Guid("28641b47-997e-4b67-9819-2a0011e05f87"), new Guid("f58d0279-1ae7-4689-a789-0e58100cca9a") },
                    { new Guid("28641b47-997e-4b67-9819-2a0011e05f87"), new Guid("ddcd8f2c-6b9c-4a85-b254-6241741f6a28") },
                    { new Guid("240cf246-08d7-4bc9-988c-8ee543b5ac85"), new Guid("51e6da48-4097-4c73-a042-7228c71e3e47") },
                    { new Guid("240cf246-08d7-4bc9-988c-8ee543b5ac85"), new Guid("dbafdeb2-c93f-4b47-b738-4b91e0b59a12") },
                    { new Guid("240cf246-08d7-4bc9-988c-8ee543b5ac85"), new Guid("2153d556-8c74-46fa-a039-e753de73fe6b") },
                    { new Guid("240cf246-08d7-4bc9-988c-8ee543b5ac85"), new Guid("5394b62e-4e6b-4f85-baa8-4447e3effdfb") },
                    { new Guid("28641b47-997e-4b67-9819-2a0011e05f87"), new Guid("51e6da48-4097-4c73-a042-7228c71e3e47") },
                    { new Guid("33cb295e-ba54-4812-8250-d76d7c2b5e03"), new Guid("dbafdeb2-c93f-4b47-b738-4b91e0b59a12") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDisciplines_DisciplineId",
                table: "StudentsDisciplines",
                column: "DisciplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsDisciplines");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
