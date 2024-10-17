using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskTeledokInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ИНН = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Наименование = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ЮЛИП = table.Column<bool>(type: "boolean", nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ДатаОбновления = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ИНН);
                });

            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    ИНН = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ФИО = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ДатаОбновления = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.ИНН);
                });

            migrationBuilder.CreateTable(
                name: "ClientsFounders",
                columns: table => new
                {
                    ИНН_Учредителя = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ИНН_Компании = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsFounders", x => x.ИНН_Учредителя);
                    table.ForeignKey(
                        name: "FK_ClientsFounders_Clients_ИНН_Компании",
                        column: x => x.ИНН_Компании,
                        principalTable: "Clients",
                        principalColumn: "ИНН",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientsFounders_Founders_ИНН_Учредителя",
                        column: x => x.ИНН_Учредителя,
                        principalTable: "Founders",
                        principalColumn: "ИНН",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsFounders_ИНН_Компании",
                table: "ClientsFounders",
                column: "ИНН_Компании",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsFounders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Founders");
        }
    }
}
