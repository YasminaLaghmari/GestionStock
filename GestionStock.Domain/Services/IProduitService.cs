using GestionStock.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Services
{
    public interface IProduitService
    {
        Produit CreateProduit(Produit newProduit);
        void DeleteProduit(Produit produit);
        IEnumerable<Produit> GetAllProduits();
        Produit GetProduitById(int id);
        Produit UpdateProduit(Produit produit);

    }
}
