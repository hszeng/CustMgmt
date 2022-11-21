using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustMgmt.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "Email", "IsDeleted", "ModifiedAt", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("73d5b5f5-3008-49b7-b0d6-cc337f1a3330"), "Customer 1 Address", new DateTime(2022, 11, 21, 10, 23, 33, 887, DateTimeKind.Unspecified), null, "Customer1@xxx.com", false, null, "Customer 1", 1002 },
                    { new Guid("8d04a48e-be4e-468e-8ce2-3ac0a0c79549"), "Customer 2 Address", new DateTime(2022, 11, 21, 10, 23, 33, 817, DateTimeKind.Unspecified), null, "Customer2@xxx.com", false, null, "Customer 2", 1002 },
                    { new Guid("7406b13e-a793-4b12-84cb-7fe2a694b9aa"), "Customer 3 Address", new DateTime(2022, 11, 21, 10, 13, 33, 887, DateTimeKind.Unspecified), null, "Customer3@xxx.com", false, null, "Customer 3", 1003 },
                    { new Guid("84556abd-1a6c-4d20-a8a7-271dd4393b2e"), "Customer 4 Address", new DateTime(2022, 11, 21, 10, 24, 33, 887, DateTimeKind.Unspecified), null, "Customer4@xxx.com", false, null, "Customer 4", 1001 },
                    { new Guid("2029db57-c15c-4c0c-80a0-c811b7995cb4"), "Customer 5 Address", new DateTime(2022, 11, 21, 11, 23, 33, 887, DateTimeKind.Unspecified), null, "Customer5@xxx.com", false, null, "Customer 5", 1002 },
                    { new Guid("5f978cf6-df6d-47a9-8ef2-d2723cc29cc8"), "Customer 6 Address", new DateTime(2022, 11, 21, 10, 23, 23, 887, DateTimeKind.Unspecified), null, "Customer6@xxx.com", false, null, "Customer 6", 1001 },
                    { new Guid("90ee3976-d672-4411-ae1c-3267baa940eb"), "Customer 7 Address", new DateTime(2022, 11, 21, 10, 23, 53, 887, DateTimeKind.Unspecified), null, "Customer7@xxx.com", false, null, "Customer 7", 1003 },
                    { new Guid("4633a79c-9f4a-48d5-ae5a-70945fb8583c"), "Customer 8 Address", new DateTime(2022, 11, 21, 10, 23, 33, 817, DateTimeKind.Unspecified), null, "Customer8@xxx.com", false, null, "Customer 8", 1001 }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedAt", "CustomerId", "DeletedAt", "IsDeleted", "ModifiedAt" },
                values: new object[,]
                {
                    { new Guid("7d8ebda9-2634-4c0f-9469-0695d6132153"), "Content of Note 1", new DateTime(2022, 11, 21, 10, 23, 33, 1, DateTimeKind.Unspecified), new Guid("73d5b5f5-3008-49b7-b0d6-cc337f1a3330"), null, false, null },
                    { new Guid("1ed47697-aa7d-48c2-aa39-305d0e13b3aa"), "Content of Note 2", new DateTime(2022, 11, 21, 10, 23, 33, 2, DateTimeKind.Unspecified), new Guid("73d5b5f5-3008-49b7-b0d6-cc337f1a3330"), null, false, null },
                    { new Guid("5f82c852-375d-4926-a3b7-84b63fc1bfae"), "Content of Note 3", new DateTime(2022, 11, 21, 10, 23, 33, 3, DateTimeKind.Unspecified), new Guid("8d04a48e-be4e-468e-8ce2-3ac0a0c79549"), null, false, null },
                    { new Guid("418a5b20-460b-4604-be17-2b0809e19acd"), "Content of Note 4", new DateTime(2022, 11, 21, 10, 23, 33, 11, DateTimeKind.Unspecified), new Guid("8d04a48e-be4e-468e-8ce2-3ac0a0c79549"), null, false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CustomerId",
                table: "Notes",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
