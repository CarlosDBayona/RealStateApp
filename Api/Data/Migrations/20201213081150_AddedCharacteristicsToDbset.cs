using Microsoft.EntityFrameworkCore.Migrations;

namespace RealStateApp.Data.Migrations
{
    public partial class AddedCharacteristicsToDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCharacteristics_Characteristic_CharacteristicId",
                table: "PropertyCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristic",
                table: "Characteristic");

            migrationBuilder.RenameTable(
                name: "Characteristic",
                newName: "Characteristics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCharacteristics_Characteristics_CharacteristicId",
                table: "PropertyCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCharacteristics_Characteristics_CharacteristicId",
                table: "PropertyCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics");

            migrationBuilder.RenameTable(
                name: "Characteristics",
                newName: "Characteristic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristic",
                table: "Characteristic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCharacteristics_Characteristic_CharacteristicId",
                table: "PropertyCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
