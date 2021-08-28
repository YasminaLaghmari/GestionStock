using GestionStock.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure
{
    public class GestionStockContext:DbContext
    {
        public DbSet<Client>Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LignesCommande> LigneCommandes { get; set; }
        public DbSet<ReRouting> Reroutings { get; set; }
        public GestionStockContext(DbContextOptions<GestionStockContext>context)
            : base(context)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder build)
        {

        }

    }
}
