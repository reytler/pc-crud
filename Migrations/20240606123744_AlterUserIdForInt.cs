using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudpcapi.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserIdForInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FOTO_PERFIL",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "NOME",
                table: "USERS");

            migrationBuilder.AlterColumn<int>(
                name: "USUARIO",
                table: "USERS",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SENHA",
                table: "USERS",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USUARIO",
                table: "USERS",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "SENHA",
                keyValue: null,
                column: "SENHA",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SENHA",
                table: "USERS",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte[]>(
                name: "FOTO_PERFIL",
                table: "USERS",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOME",
                table: "USERS",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
