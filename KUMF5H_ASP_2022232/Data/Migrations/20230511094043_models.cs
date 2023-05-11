using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUMF5H_ASP_2022232.Data.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodUserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Foodrequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    PictureContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodrequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foodrequests_AspNetUsers_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Foodrequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Foodrequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Foodrequests_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foodrequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Choosen = table.Column<bool>(type: "bit", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Foodrequests_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foodrequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "FoodUserName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "401059f4-d7a2-4bc0-8340-818c8398f45c", 0, "366a0f72-0be0-47f8-8f26-4ab01316e363", "FoodUser", null, true, "Anita", "anita@gmail.com", "Koczó", false, null, null, "ANITA@GMAIL.COM", "AQAAAAEAACcQAAAAEAYFj6fPAY7IJ6GNOcyXYt9CahKArU718kAvlQaj1evPrPXKKgqjb2JEwGASRg26QA==", null, false, "ab686dad-5704-4520-9e0a-515917556a03", false, "anita@gmail.com" },
                    { "db7dc19e-c77a-4000-834c-f0e8dfdc4865", 0, "e266d7a8-4790-4b35-9eb0-e48cc9f76bc9", "FoodUser", null, true, "Tibor", "tibi@gmail.com", "Bognár", false, null, null, "TIBI@GMAIL.COM", "AQAAAAEAACcQAAAAEDruCrL5nM+ZjYzQl3g05oNuRZb+xdg6RjKod2ClnoLMYJWEpTdSSoaF33wYzYz7ng==", null, false, "c541d067-d551-4004-a29a-4eb4b13b6bbb", false, "tibi@gmail.com" },
                    { "f32790dd-f30d-4d11-888f-c93cabf90f0a", 0, "8b882a80-087f-408b-8c82-db918da6d958", "FoodUser", null, true, "Bence", "bence@gmail.com", "Bognár", false, null, null, "BENCE@GMAIL.COM", "AQAAAAEAACcQAAAAEBG82lyDCwiL47RBp2TEv0ySChM9j4rPQSz9f+iP4fkoJFGaCLVIUj0cLCsBecxZBA==", null, false, "0c49bd11-f74a-4f2d-9054-aa21b9a5af7e", false, "bence@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Foodrequests",
                columns: new[] { "Id", "Description", "IsDone", "Name", "PictureContentType", "RequestorId" },
                values: new object[,]
                {
                    { "3", "Tosted.", false, "Toast", "Image/jpeg", "401059f4-d7a2-4bc0-8340-818c8398f45c" },
                    { "37c94d3a-f6bf-4dee-b8c5-edd3e4620959", "Sülthus", false, "Stake", "Image/jpeg", "f32790dd-f30d-4d11-888f-c93cabf90f0a" },
                    { "4", "All the chocklate", false, "Chocklate ckae", "Image/png", "401059f4-d7a2-4bc0-8340-818c8398f45c" },
                    { "5", "I want to see myself eating", false, "Mirror ckae", "Image/jpeg", "401059f4-d7a2-4bc0-8340-818c8398f45c" },
                    { "de9de71c-4f25-4735-b49e-c29a763c127b", "Nyers hal", false, "Susi", "Image/jpeg", "f32790dd-f30d-4d11-888f-c93cabf90f0a" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ContractorId", "RequestId", "Text" },
                values: new object[,]
                {
                    { "439247d1-6f94-4924-b8b6-0d3ce3ba7ceb", "db7dc19e-c77a-4000-834c-f0e8dfdc4865", "3", "Hi" },
                    { "859dde70-471f-4d91-8a75-1821990dc9a1", "db7dc19e-c77a-4000-834c-f0e8dfdc4865", "4", "Hello" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[,]
                {
                    { "800f27d9-d9e1-4ea9-bafb-99eba74d07c2", "Rizs", "de9de71c-4f25-4735-b49e-c29a763c127b", "Rizs" },
                    { "908884d8-dc26-4207-911c-2478cc5ec821", "Dark", "4", "Choko" },
                    { "edab33f6-8095-45ef-a98c-c36de3c607e4", "Tuna", "de9de71c-4f25-4735-b49e-c29a763c127b", "Hal" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Choosen", "ContractorId", "FoodId" },
                values: new object[,]
                {
                    { "3ba00c9f-2ff4-4e54-aebf-2f3fc697ee16", false, "db7dc19e-c77a-4000-834c-f0e8dfdc4865", "4" },
                    { "9639e010-d1b4-4b1e-b316-8f5b3219ee9a", false, "db7dc19e-c77a-4000-834c-f0e8dfdc4865", "3" },
                    { "be42cb0c-c745-4201-ba7d-6050fb1aa1f0", false, "f32790dd-f30d-4d11-888f-c93cabf90f0a", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ContractorId",
                table: "Comments",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Foodrequests_RequestorId",
                table: "Foodrequests",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FoodId",
                table: "Ingredients",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ContractorId",
                table: "Offers",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_FoodId",
                table: "Offers",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Foodrequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db7dc19e-c77a-4000-834c-f0e8dfdc4865");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "401059f4-d7a2-4bc0-8340-818c8398f45c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f32790dd-f30d-4d11-888f-c93cabf90f0a");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FoodUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
