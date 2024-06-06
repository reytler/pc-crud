using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudpcapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SUJEITOS",
                columns: table => new
                {
                    CODIGO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VULGO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDADE = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ALTURA_APROXIMADA = table.Column<int>(type: "int", nullable: false),
                    CIDADE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RUA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COMPLEMENTO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REFERENCIA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUJEITOS", x => x.CODIGO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USUARIO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROLE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FOTO_PERFIL = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID_USUARIO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PHOTOS",
                columns: table => new
                {
                    CODIGO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODIGO_SUJEITO = table.Column<int>(type: "int", nullable: false),
                    PHOTO_BYTES = table.Column<byte[]>(type: "longblob", nullable: false),
                    SujeitoId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTOS", x => x.CODIGO);
                    table.ForeignKey(
                        name: "FK_PHOTOS_SUJEITOS_SujeitoId1",
                        column: x => x.SujeitoId1,
                        principalTable: "SUJEITOS",
                        principalColumn: "CODIGO");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PHOTOS_SujeitoId1",
                table: "PHOTOS",
                column: "SujeitoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHOTOS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "SUJEITOS");
        }
    }
}
