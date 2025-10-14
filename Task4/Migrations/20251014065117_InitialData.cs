using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task4.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leo Tolstoy" },
                    { 2, new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fyodor Dostoevsky" },
                    { 3, new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Austen" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1869, "War and Peace" },
                    { 2, 1, 1877, "Anna Karenina" },
                    { 3, 1, 1886, "The Death of Ivan Ilyich" },
                    { 4, 2, 1866, "Crime and Punishment" },
                    { 5, 2, 1880, "The Brothers Karamazov" },
                    { 6, 2, 1869, "The Idiot" },
                    { 7, 3, 1813, "Pride and Prejudice" },
                    { 8, 3, 1811, "Sense and Sensibility" },
                    { 9, 3, 1815, "Emma" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);
        }
    }
}
