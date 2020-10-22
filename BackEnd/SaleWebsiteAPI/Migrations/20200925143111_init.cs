using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleWebsiteAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    generalityName = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    displayname = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    avatar = table.Column<string>(nullable: true),
                    gender = table.Column<bool>(nullable: false),
                    birthDay = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    importPrice = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    sale = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    size = table.Column<int>(nullable: true),
                    color = table.Column<int>(nullable: true),
                    amount = table.Column<int>(nullable: false),
                    viewCount = table.Column<int>(nullable: false),
                    categoryId = table.Column<int>(nullable: true),
                    providerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Providers_providerId",
                        column: x => x.providerId,
                        principalTable: "Providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createDate = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    senderId = table.Column<Guid>(nullable: false),
                    receiverId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_receiverId",
                        column: x => x.receiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Users_senderId",
                        column: x => x.senderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    feeShip = table.Column<int>(nullable: false),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    guess = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    createDate = table.Column<DateTime>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    userId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlImage = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(nullable: false),
                    unitPrice = table.Column<int>(nullable: false),
                    sale = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    orderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    createDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<Guid>(nullable: false),
                    evaluationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Replies_Evaluations_evaluationId",
                        column: x => x.evaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replies_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("078269d8-1a12-4592-b92e-7ff1a876a5f2"), new Guid("4557893f-1f56-4b6f-bb3b-caefd62c8c49") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "generalityName", "name", "status" },
                values: new object[,]
                {
                    { 1, "Quần Áo", "Áo Sơ Mi", 0 },
                    { 2, "Quần Áo", "Quần Tây", 0 },
                    { 3, "Quần Áo", "Áo Thun", 0 },
                    { 4, "Quần Áo", "Quần Kaki", 0 }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "id", "name", "status" },
                values: new object[,]
                {
                    { 1, "Việt Tiến", 0 },
                    { 2, "Cty May Sông Hồng", 0 },
                    { 3, "Cty May Nhà Bè", 0 },
                    { 4, "Cty Giditex", 0 },
                    { 5, "Cty Vinatex", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreationDate", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("078269d8-1a12-4592-b92e-7ff1a876a5f2"), "c2c9dc7b-a163-497c-968e-4c4eb2832dd4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator role", "Admin", "Admin" },
                    { new Guid("6d9186ba-2cd6-4b6c-b729-4e605de1019f"), "cdc5ebea-2206-43ec-a535-ca2e3bfcff40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User role", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "avatar", "birthDay", "displayname", "gender", "phone", "status" },
                values: new object[] { new Guid("4557893f-1f56-4b6f-bb3b-caefd62c8c49"), 0, "74857604-45a3-4c4d-a956-70a6e40ba47b", "thienvovan0112@gmail.com", true, false, null, "some-admin-email@nonce.fake", "admin", "AQAAAAEAACcQAAAAEEwuKD9/sWNHPasdmyV/INotIDt5a3RuMvrfSFOSsRMklcZlMyiSY1eqT/HycX828w==", null, false, "", false, "admin", null, null, new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", false, null, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "amount", "categoryId", "color", "description", "importPrice", "name", "price", "providerId", "rating", "sale", "size", "status", "viewCount" },
                values: new object[,]
                {
                    { 1, 0, 1, 6, "mô tả sản phẩm 1", 100000, "Áo Sơ Mi", 150000, 1, 5, 0, 2, 0, 0 },
                    { 2, 0, 1, 2, "mô tả sản phẩm 2", 80000, "Áo Sơ Mi Tay Ngắn", 120000, 2, 5, 0, 3, 0, 0 },
                    { 3, 0, 2, 6, "mô tả sản phẩm 3", 200000, "Quần Tây", 250000, 3, 5, 0, 2, 0, 0 },
                    { 4, 0, 3, 1, "mô tả sản phẩm 4", 50000, "Áo Thun", 75000, 4, 5, 0, 2, 0, 0 },
                    { 5, 0, 4, 7, "mô tả sản phẩm 5", 180000, "Quần Kaki", 220000, 5, 5, 0, 2, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_receiverId",
                table: "Chats",
                column: "receiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_senderId",
                table: "Chats",
                column: "senderId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_productId",
                table: "Evaluations",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_userId",
                table: "Evaluations",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_productId",
                table: "Images",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderId",
                table: "OrderDetails",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_productId",
                table: "OrderDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_providerId",
                table: "Products",
                column: "providerId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_evaluationId",
                table: "Replies",
                column: "evaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_userId",
                table: "Replies",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
