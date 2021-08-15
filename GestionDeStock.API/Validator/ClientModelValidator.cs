using FluentValidation;
using GestionDeStock.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Validator
{
    public class ClientModelValidator : AbstractValidator<ClientModel>
    {
        public ClientModelValidator()
        {
            RuleFor(x => x.Prenom).NotNull().Length(10, 20);
            RuleFor(x => x.Nom).NotNull().Length(10, 20);
            RuleFor(x => x.Adresse).NotNull().Length(10, 20);


        }
    }
}
