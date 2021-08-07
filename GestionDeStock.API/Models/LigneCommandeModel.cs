using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Models
{
    public class LigneCommandeModel
    {
        public int IdProduit { get; set; }
        public int quantite { get; set; }
    }
}
