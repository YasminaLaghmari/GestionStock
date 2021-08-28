using GestionDeStock.API.Models;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionDeStock.API.Applications.Commands
{
    public class AddClientHandler : IRequestHandler<AddClientCommand, ClientModel>
    {
        private readonly IClientService _serviceClient;
        public AddClientHandler(IClientService _client)
        {
            this._serviceClient = _client;
        }
        public Task<ClientModel> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            ClientModel result = null;
              var clientCreated = _serviceClient.CreateClient(new Client()
                { Nom =request.Item.Nom,
                Adresse=request.Item.Adresse,
                Prenom=request.Item.Prenom

                }) ;
            result = request.Item;
            return Task.FromResult(result);
               
           
        }

       
    }
}
