using GestionStock.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Services
{
    public interface ICommandeService
    {
        IEnumerable<Commande> GetAllCommandes();
        Commande GetCommandeById(int id);
        Commande CreateCommande(Commande newCommande);
        Commande UpdateCommande(Commande commande);
        void DeleteCommande(Commande commande);
        void CreateCommandeAvecClient(Client client, Commande commande, List<LignesCommande> ligneCommandes);
    }
}
