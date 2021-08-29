using GestionDeStock.API.Models;
using GestionStock.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Applications.Queries
{
    public class SelectAllClientQuery : IRequest<List<ClientModel>>
    {
        public ClientModel Item { get;  set; }
    }
}
