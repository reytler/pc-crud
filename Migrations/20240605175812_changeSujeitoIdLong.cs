using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudpcapi.Migrations
{
    /// <inheritdoc />
    public partial class changeSujeitoIdLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PHOTOS_SUJEITOS_SujeitoId1",
                table: "PHOTOS");

            migrationBuilder.DropIndex(
                name: "IX_PHOTOS_SujeitoId1",
                table: "PHOTOS");

            migrationBuilder.DropColumn(
                name: "SujeitoId1",
                table: "PHOTOS");

            migrationBuilder.AlterColumn<string>(
                name: "REFERENCIA",
                table: "SUJEITOS",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "COMPLEMENTO",
                table: "SUJEITOS",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "CODIGO_SUJEITO",
                table: "PHOTOS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PHOTOS_CODIGO_SUJEITO",
                table: "PHOTOS",
                column: "CODIGO_SUJEITO");

            migrationBuilder.AddForeignKey(
                name: "FK_PHOTOS_SUJEITOS_CODIGO_SUJEITO",
                table: "PHOTOS",
                column: "CODIGO_SUJEITO",
                principalTable: "SUJEITOS",
                principalColumn: "CODIGO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PHOTOS_SUJEITOS_CODIGO_SUJEITO",
                table: "PHOTOS");

            migrationBuilder.DropIndex(
                name: "IX_PHOTOS_CODIGO_SUJEITO",
                table: "PHOTOS");

            migrationBuilder.UpdateData(
                table: "SUJEITOS",
                keyColumn: "REFERENCIA",
                keyValue: null,
                column: "REFERENCIA",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "REFERENCIA",
                table: "SUJEITOS",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SUJEITOS",
                keyColumn: "COMPLEMENTO",
                keyValue: null,
                column: "COMPLEMENTO",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "COMPLEMENTO",
                table: "SUJEITOS",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CODIGO_SUJEITO",
                table: "PHOTOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "SujeitoId1",
                table: "PHOTOS",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PHOTOS_SujeitoId1",
                table: "PHOTOS",
                column: "SujeitoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PHOTOS_SUJEITOS_SujeitoId1",
                table: "PHOTOS",
                column: "SujeitoId1",
                principalTable: "SUJEITOS",
                principalColumn: "CODIGO");
        }
    }
}
