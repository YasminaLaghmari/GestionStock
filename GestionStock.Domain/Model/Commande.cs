using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Model
{
    [Table("Commande")]
    public class Commande
    {
        [Key]
        public int Id { get; set; }
        public DateTime DteCommande { get; set; }
        public decimal Total { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public ICollection<LignesCommande> LignesCommande {get;set;}

    }
}
