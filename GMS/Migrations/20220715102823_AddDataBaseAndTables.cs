using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Migrations
{
    public partial class AddDataBaseAndTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    father_husband_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    member_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    register_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cnic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicle_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StockCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock_category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock_sub_category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit_sale_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_purchase_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    member_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    discount_type = table.Column<int>(type: "int", nullable: true),
                    precentage_value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoices_Members_member_id",
                        column: x => x.member_id,
                        principalTable: "Members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueLockers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locker_id = table.Column<int>(type: "int", nullable: false),
                    member_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLockers", x => x.id);
                    table.ForeignKey(
                        name: "FK_IssueLockers_Lockers_locker_id",
                        column: x => x.locker_id,
                        principalTable: "Lockers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueLockers_Members_member_id",
                        column: x => x.member_id,
                        principalTable: "Members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockSubCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stock_category_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSubCategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_StockSubCategories_StockCategories_stock_category_id",
                        column: x => x.stock_category_id,
                        principalTable: "StockCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersSubscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_id = table.Column<int>(type: "int", nullable: false),
                    subscription_plan_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersSubscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_MembersSubscriptions_Members_member_id",
                        column: x => x.member_id,
                        principalTable: "Members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersSubscriptions_SubscriptionPlans_subscription_plan_id",
                        column: x => x.subscription_plan_id,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationsReads",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    notification_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationsReads", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotificationsReads_Notifications_notification_id",
                        column: x => x.notification_id,
                        principalTable: "Notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationsReads_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock_sub_category_id = table.Column<int>(type: "int", nullable: false),
                    unit_sale_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_purchase_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    threshold_value = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stocks_StockSubCategories_stock_sub_category_id",
                        column: x => x.stock_sub_category_id,
                        principalTable: "StockSubCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subscription_id = table.Column<int>(type: "int", nullable: false),
                    payment_type = table.Column<int>(type: "int", nullable: false),
                    discount_type = table.Column<int>(type: "int", nullable: true),
                    percentage_values = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modify_by = table.Column<int>(type: "int", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MembersSubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_MembersSubscriptions_MembersSubscriptionId",
                        column: x => x.MembersSubscriptionId,
                        principalTable: "MembersSubscriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "created_at", "created_by", "is_active", "is_deleted", "modify_at", "modify_by", "name" },
                values: new object[] { 1, new DateTime(2022, 7, 15, 15, 28, 21, 618, DateTimeKind.Local).AddTicks(4925), 1, true, false, null, null, "Super Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "created_at", "created_by", "is_active", "is_deleted", "modify_at", "modify_by", "name" },
                values: new object[] { 2, new DateTime(2022, 7, 15, 15, 28, 21, 618, DateTimeKind.Local).AddTicks(4939), 1, true, false, null, null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_member_id",
                table: "Invoices",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLockers_locker_id",
                table: "IssueLockers",
                column: "locker_id");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLockers_member_id",
                table: "IssueLockers",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_MembersSubscriptions_member_id",
                table: "MembersSubscriptions",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_MembersSubscriptions_subscription_plan_id",
                table: "MembersSubscriptions",
                column: "subscription_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsReads_notification_id",
                table: "NotificationsReads",
                column: "notification_id");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsReads_user_id",
                table: "NotificationsReads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MembersSubscriptionId",
                table: "Payments",
                column: "MembersSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_stock_sub_category_id",
                table: "Stocks",
                column: "stock_sub_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_StockSubCategories_stock_category_id",
                table: "StockSubCategories",
                column: "stock_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "IssueLockers");

            migrationBuilder.DropTable(
                name: "NotificationsReads");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Lockers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "MembersSubscriptions");

            migrationBuilder.DropTable(
                name: "StockSubCategories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");

            migrationBuilder.DropTable(
                name: "StockCategories");
        }
    }
}
