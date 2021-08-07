using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Models
{
    public class ModelCreateCommande
    {
        public IEnumerable<LigneCommandeModel> CommandeLignes { get; set; }
        public ClientModel client { get; set; }
    }
}
