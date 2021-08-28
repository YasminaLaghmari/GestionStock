using GestionDeStock.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Applications.Commands
{
    public class AddClientCommand : IRequest<ClientModel>
    {
        public ClientModel Item { get; set; }

    }
}
