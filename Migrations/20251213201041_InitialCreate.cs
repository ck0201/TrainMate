using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SelfLearning.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "train_master",
                columns: table => new
                {
                    train_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    train_no = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    train_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_train_master", x => x.train_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_train_master_train_no",
                table: "train_master",
                column: "train_no",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "train_master");
        }
    }
}
