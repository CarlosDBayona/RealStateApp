using Microsoft.EntityFrameworkCore.Migrations;

namespace RealStateApp.Data.Migrations
{
    public partial class UpdatedDbContextNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Characteristic_CharacteristicId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_CharacteristicType_CharacteristicTypeId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Properties_PropertyId",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacteristicType",
                table: "CharacteristicType");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "PropertyCharacteristics");

            migrationBuilder.RenameTable(
                name: "CharacteristicType",
                newName: "CharacteristicTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Type_PropertyId",
                table: "PropertyCharacteristics",
                newName: "IX_PropertyCharacteristics_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Type_CharacteristicTypeId",
                table: "PropertyCharacteristics",
                newName: "IX_PropertyCharacteristics_CharacteristicTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Type_CharacteristicId",
                table: "PropertyCharacteristics",
                newName: "IX_PropertyCharacteristics_CharacteristicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyCharacteristics",
                table: "PropertyCharacteristics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacteristicTypes",
                table: "CharacteristicTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCharacteristics_Characteristic_CharacteristicId",
                table: "PropertyCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCharacteristics_CharacteristicTypes_CharacteristicTypeId",
                table: "PropertyCharacteristics",
                column: "CharacteristicTypeId",
                principalTable: "CharacteristicTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCharacteristics_Properties_PropertyId",
                table: "PropertyCharacteristics",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCharacteristics_Characteristic_CharacteristicId",
                table: "PropertyCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCharacteristics_CharacteristicTypes_CharacteristicTypeId",
                table: "PropertyCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCharacteristics_Properties_PropertyId",
                table: "PropertyCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyCharacteristics",
                table: "PropertyCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacteristicTypes",
                table: "CharacteristicTypes");

            migrationBuilder.RenameTable(
                name: "PropertyCharacteristics",
                newName: "Type");

            migrationBuilder.RenameTable(
                name: "CharacteristicTypes",
                newName: "CharacteristicType");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyCharacteristics_PropertyId",
                table: "Type",
                newName: "IX_Type_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyCharacteristics_CharacteristicTypeId",
                table: "Type",
                newName: "IX_Type_CharacteristicTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyCharacteristics_CharacteristicId",
                table: "Type",
                newName: "IX_Type_CharacteristicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacteristicType",
                table: "CharacteristicType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Characteristic_CharacteristicId",
                table: "Type",
                column: "CharacteristicId",
                principalTable: "Characteristic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_CharacteristicType_CharacteristicTypeId",
                table: "Type",
                column: "CharacteristicTypeId",
                principalTable: "CharacteristicType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Properties_PropertyId",
                table: "Type",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
