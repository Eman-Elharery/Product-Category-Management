using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.Migrations
{
    /// <inheritdoc />
    public partial class AddImageNameToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2028, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2027, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2027, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2029, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2029, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2029, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2031, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2031, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2028, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2029, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2027, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2028, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2029, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpiryDate", "ImageName" },
                values: new object[] { new DateTime(2030, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2028, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2027, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2027, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2029, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2029, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpiryDate",
                value: new DateTime(2029, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpiryDate",
                value: new DateTime(2031, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpiryDate",
                value: new DateTime(2031, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpiryDate",
                value: new DateTime(2028, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpiryDate",
                value: new DateTime(2029, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpiryDate",
                value: new DateTime(2027, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpiryDate",
                value: new DateTime(2028, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpiryDate",
                value: new DateTime(2029, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpiryDate",
                value: new DateTime(2030, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
