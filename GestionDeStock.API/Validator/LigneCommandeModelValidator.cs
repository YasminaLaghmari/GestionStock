using FluentValidation;
using GestionDeStock.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Validator
{
    public class LigneCommandeModelValidator : AbstractValidator<LigneCommandeModel>
    {
        public LigneCommandeModelValidator()
        {

        }
    }
}
