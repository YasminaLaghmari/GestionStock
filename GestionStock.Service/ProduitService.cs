using GestionStock.Domain.Interface;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Service
{
    public class ProduitService : IProduitService
    {
        private readonly IRepository<Produit> _repository;
        public ProduitService(IRepository<Produit>repository)
        {
            _repository = repository;
        }

        public Produit CreateProduit(Produit newProduit)
        {
            var produit = _repository.Add(newProduit);
            _repository.SaveChanges();
            return produit;
        }

        public void DeleteProduit(Produit produit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produit> GetAllProduits()
        {
            throw new NotImplementedException();
        }

        public Produit GetProduitById(int id)
        {
            throw new NotImplementedException();
        }

        public Produit UpdateProduit(Produit produit)
        {
            throw new NotImplementedException();
        }
    }


}
