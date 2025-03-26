using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPicPay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableUsersAddCollunTypeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "varchar(500)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "varchar(500)", nullable: false),
                    Password = table.Column<string>(type: "varchar(500)", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    TypeUser = table.Column<char>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CostumerName = table.Column<string>(type: "varchar(500)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
