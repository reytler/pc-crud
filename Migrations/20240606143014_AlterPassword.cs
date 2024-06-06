using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudpcapi.Migrations
{
    /// <inheritdoc />
    public partial class AlterPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ALTERAR_SENHA",
                table: "USERS",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ALTERAR_SENHA",
                table: "USERS");
        }
    }
}
