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
    public class CommandeService : ICommandeService
    {
        private IRepository<Commande> _repositoryCommande;
        private IRepository<Client> _repositoryClient;
        private IRepository<LignesCommande> _repositoryLignesCommande;
        public CommandeService(IRepository<Commande> repository, 
            IRepository<Client> repositoryClient, IRepository<LignesCommande> repositoryLignesCommande)
        {
            _repositoryCommande = repository;
            _repositoryClient = repositoryClient;
            _repositoryLignesCommande = repositoryLignesCommande;

        }
        public Commande CreateCommande(Commande newCommande)
        {
            throw new NotImplementedException();
        }

        public void CreateCommandeAvecClient(Client client, Commande commande, List<LignesCommande> ligneCommandes)
        {
            var clientCreated = _repositoryClient.Add(client);
            _repositoryClient.SaveChanges();
            commande.Client = clientCreated;
            var commandeCreated = _repositoryCommande.Add(commande);
            _repositoryCommande.SaveChanges();
            foreach (var ligne in ligneCommandes)
            {
                ligne.Commande = commandeCreated;
                _repositoryLignesCommande.Add(ligne);
                _repositoryLignesCommande.SaveChanges();
            }
          
        }

        public void DeleteCommande(Commande commande)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commande> GetAllCommandes()
        {
            throw new NotImplementedException();
        }

        public Commande GetCommandeById(int id)
        {
            throw new NotImplementedException();
        }

        public Commande UpdateCommande(Commande commande)
        {
            throw new NotImplementedException();
        }
    }
}
