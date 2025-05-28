using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "Jdoe@hotmail.com", "Jane", "Doe" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "ZYuan@gmail.com", "Yuan", "Zhu" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "NDemara@yahoo.com", "Nicole", "Demara" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "delores@hotmail.com", "Delores", "Del Rio" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "efren@aol.com", "Efren", "Herrera" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "MaryEllen@yahoo.com", "Mary Ellen", "Walton" });
        }
    }
}
