using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_for_66bit.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneNumberNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Interns",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Interns",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+799912345672");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Interns",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Interns",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "899912345672");
        }
    }
}
