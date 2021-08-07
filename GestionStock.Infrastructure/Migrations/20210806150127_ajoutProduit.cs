using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStock.Infrastructure.Migrations
{
    public partial class ajoutProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignesCommande_Produits_ProduitId",
                table: "LignesCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.RenameTable(
                name: "Produits",
                newName: "Produit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produit",
                table: "Produit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LignesCommande_Produit_ProduitId",
                table: "LignesCommande",
                column: "ProduitId",
                principalTable: "Produit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignesCommande_Produit_ProduitId",
                table: "LignesCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produit",
                table: "Produit");

            migrationBuilder.RenameTable(
                name: "Produit",
                newName: "Produits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LignesCommande_Produits_ProduitId",
                table: "LignesCommande",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
