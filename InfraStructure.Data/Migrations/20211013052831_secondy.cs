using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraStructure.Data.Migrations
{
    public partial class secondy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPrincipal_Users_GroupsId",
                table: "GroupPrincipal");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPrincipal_Users_MembersId",
                table: "GroupPrincipal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Principals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Principals",
                table: "Principals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPrincipal_Principals_GroupsId",
                table: "GroupPrincipal",
                column: "GroupsId",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPrincipal_Principals_MembersId",
                table: "GroupPrincipal",
                column: "MembersId",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPrincipal_Principals_GroupsId",
                table: "GroupPrincipal");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPrincipal_Principals_MembersId",
                table: "GroupPrincipal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Principals",
                table: "Principals");

            migrationBuilder.RenameTable(
                name: "Principals",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPrincipal_Users_GroupsId",
                table: "GroupPrincipal",
                column: "GroupsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPrincipal_Users_MembersId",
                table: "GroupPrincipal",
                column: "MembersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
