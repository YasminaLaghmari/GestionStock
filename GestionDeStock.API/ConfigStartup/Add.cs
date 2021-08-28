using FluentValidation;
using FluentValidation.AspNetCore;
using GestionDeStock.API.Models;
using GestionDeStock.API.Validator;
using GestionStock.Domain.Interface;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using GestionStock.Infrastructure.Repositories;
using GestionStock.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.ConfigStartup
{
    public static class Add
    {
        
        
        public static void AddInjectionsRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Client>, ClientRepository>();
            services.AddTransient<IRepository<Produit>, ProduitRepository>();
            services.AddTransient<IRepository<Commande>, CommandeRepository>();
            services.AddTransient<IRepository<LignesCommande>, LignesCommandeRepository>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IProduitService, ProduitService>();
            services.AddTransient<ICommandeService, CommandeService>();
            services.AddTransient<ILignesCommandeService, LignesCommandeService>();
            services.AddTransient<IUserService, UserService>();
        }

       

        public static void AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidation();

            services.AddTransient<IValidator<ClientModel>, ClientModelValidator>();
            services.AddTransient<IValidator<LigneCommandeModel>, LigneCommandeModelValidator>();
            services.AddTransient<IValidator<UserModel>, UserModelValidator>();
        }
    }
}
