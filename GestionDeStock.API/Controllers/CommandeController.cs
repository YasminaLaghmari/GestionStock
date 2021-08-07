using GestionDeStock.API.Models;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using GestionStock.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly ICommandeService _serviceCommande;
        public CommandeController(ICommandeService serviceCommande)
        {
            _serviceCommande = serviceCommande;
        }
        [HttpPost]
        public ActionResult CreateCommande(ModelCreateCommande model)
        {
            var client = new Client
            {
                Nom = model.client.Nom,
                Prenom = model.client.Prenom,
                Adresse = model.client.Adresse
            };
            var commande = new Commande
            {
                Client = client,

                DteCommande = DateTime.Now,
                Total = 154
            };

            var ligneCommandes = new List<LignesCommande>();
            foreach (var ligne in model.CommandeLignes)
            {
                var ligneCommande = new LignesCommande
                {
                    IdProduit = ligne.IdProduit,
                    Quantite = ligne.quantite
                };
                ligneCommandes.Add(ligneCommande);
            }
            _serviceCommande.CreateCommandeAvecClient(client,commande, ligneCommandes);
        }
    }
}
