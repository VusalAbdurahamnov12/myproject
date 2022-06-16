using Microsoft.EntityFrameworkCore.Migrations;

namespace mea.Migrations
{
    public partial class createdDbj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Menus",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
