using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Model
{
    [Table("Produit")]
    public class Produit
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
    }
}
