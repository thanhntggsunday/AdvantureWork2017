using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvantureWork.Model.Migrations
{
    public partial class AddPermissionTablesRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role_Permission");

            migrationBuilder.DropTable(
                name: "Function_Action");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.CreateTable(
                name: "AppActions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionKey", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppFunctions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IconCss = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionKey", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppFunction_Action",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FunctionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionsID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function_ActionKey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppFunction_Action_AppActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "AppActions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppFunction_Action_AppFunctions_FunctionsID",
                        column: x => x.FunctionsID,
                        principalTable: "AppFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppRole_Permission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Function_ActionID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_PermissionKey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppRole_Permission_AppFunction_Action_Function_ActionID",
                        column: x => x.Function_ActionID,
                        principalTable: "AppFunction_Action",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRole_Permission_AppRoles_AppRolesId",
                        column: x => x.AppRolesId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFunction_Action_ActionId",
                table: "AppFunction_Action",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFunction_Action_FunctionsID",
                table: "AppFunction_Action",
                column: "FunctionsID");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Permission_AppRolesId",
                table: "AppRole_Permission",
                column: "AppRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRole_Permission_Function_ActionID",
                table: "AppRole_Permission",
                column: "Function_ActionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRole_Permission");

            migrationBuilder.DropTable(
                name: "AppFunction_Action");

            migrationBuilder.DropTable(
                name: "AppActions");

            migrationBuilder.DropTable(
                name: "AppFunctions");

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionKey", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IconCss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionKey", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Function_Action",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FunctionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function_ActionKey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Function_Action_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Function_Action_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Function_ActionID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_PermissionKey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Role_Permission_AppRoles_AppRolesId",
                        column: x => x.AppRolesId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_Permission_Function_Action_Function_ActionID",
                        column: x => x.Function_ActionID,
                        principalTable: "Function_Action",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Function_Action_ActionId",
                table: "Function_Action",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Function_Action_FunctionId",
                table: "Function_Action",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permission_AppRolesId",
                table: "Role_Permission",
                column: "AppRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permission_Function_ActionID",
                table: "Role_Permission",
                column: "Function_ActionID");
        }
    }
}
