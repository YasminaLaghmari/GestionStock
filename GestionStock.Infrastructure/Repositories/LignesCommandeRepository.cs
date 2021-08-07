using GestionStock.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Repositories
{
    public class LignesCommandeRepository:Repository<LignesCommande>
    {
        public LignesCommandeRepository(GestionStockContext context) : base(context)
        {

        }
    }
}
