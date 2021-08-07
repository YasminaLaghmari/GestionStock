using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Model
{
    [Table("LignesCommande")]
    public class LignesCommande
    {

        [Key]
        public int Id { get; set; }
        public int Quantite { get; set; }
        public decimal Total { get; set; }
        public int IdProduit { get; set; }
        public Produit Produit { get; set; }
        public int IdCommande { get; set; }
        public Commande Commande { get; set; }



    }
}
