using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryAuto.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Reserved");

            migrationBuilder.RenameColumn(
                name: "product_Id",
                table: "Reserved",
                newName: "ReservedId");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Reserved",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ReservedId",
                table: "Reserved",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingDate",
                table: "Reserved",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reserved",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservedBook",
                table: "Reserved",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Reserved",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserved",
                table: "Reserved",
                column: "ReservedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserved_BookId",
                table: "Reserved",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserved_Book_BookId",
                table: "Reserved",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserved_Book_BookId",
                table: "Reserved");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserved",
                table: "Reserved");

            migrationBuilder.DropIndex(
                name: "IX_Reserved_BookId",
                table: "Reserved");

            migrationBuilder.DropColumn(
                name: "EndingDate",
                table: "Reserved");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reserved");

            migrationBuilder.DropColumn(
                name: "ReservedBook",
                table: "Reserved");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Reserved");

            migrationBuilder.RenameTable(
                name: "Reserved",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "ReservedId",
                table: "order",
                newName: "product_Id");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "order",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "product_Id",
                table: "order",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "BookId");
        }
    }
}
