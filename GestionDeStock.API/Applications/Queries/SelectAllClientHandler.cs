using GestionDeStock.API.Models;
using GestionStock.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace GestionDeStock.API.Applications.Queries
{
    public class SelectAllClientHandler : IRequestHandler<SelectAllClientQuery, List<ClientModel>>
    {

        
        private readonly IClientService _serviceClient;
        public SelectAllClientHandler(IClientService _client)
        {
            this._serviceClient = _client;
        }

        
        public Task<List<ClientModel>> Handle(SelectAllClientQuery request, CancellationToken cancellationToken)
        {
            return (Task<List<ClientModel>>)_serviceClient.GetAllClients();
            
        }
    }
}
