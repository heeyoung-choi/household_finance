using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class delete_filename_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "AppFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "AppFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
