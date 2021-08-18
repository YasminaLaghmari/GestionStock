using FluentValidation;
using GestionDeStock.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Validator
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotNull().Length(10, 20);
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Password).NotNull();
            //RuleFor(x => x.PasswordSalt).NotNull();
            RuleFor(x => x.IsAdmin).NotNull();
            RuleFor(x => x.isAgent).NotNull();
            RuleFor(x => x.isManager).NotNull();
            RuleFor(x => x.isUser).NotNull();
        }
    }
}
