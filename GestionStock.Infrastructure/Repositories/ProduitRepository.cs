using GestionStock.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Repositories
{
    public class ProduitRepository : Repository<Produit>
    {
        public ProduitRepository(GestionStockContext context) : base(context)
        {

        }
    }
}
