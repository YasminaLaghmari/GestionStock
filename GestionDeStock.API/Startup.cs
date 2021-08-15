using FluentValidation;
using FluentValidation.AspNetCore;
using GestionDeStock.API.Models;
using GestionDeStock.API.Validator;
using GestionStock.Domain.Interface;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using GestionStock.Infrastructure;
using GestionStock.Infrastructure.Repositories;
using GestionStock.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GestionStockContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("Default"),
                    x=>x.MigrationsAssembly("GestionStock.Infrastructure"));
            });

           
            //Dependacy injection 
            services.AddTransient<IRepository<Client>,ClientRepository>();
            services.AddTransient<IRepository<Produit>, ProduitRepository>();
            services.AddTransient<IRepository<Commande>, CommandeRepository>();
            services.AddTransient<IRepository<LignesCommande>, LignesCommandeRepository>();


            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IClientService,ClientService>();
            services.AddTransient<IProduitService,ProduitService>();
            services.AddTransient<ICommandeService,CommandeService>();
            services.AddTransient<ILignesCommandeService,LignesCommandeService>();
            services.AddTransient<IUserService, UserService>();

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestion de commande.API", Version = "v1" });
            });


            


            //key JWT

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));

            //REFERENCE JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //Configuratuon jwt
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

           
            services.AddFluentValidation();

            services.AddTransient<IValidator<ClientModel>, ClientModelValidator>();
            services.AddTransient<IValidator<LigneCommandeModel>, LigneCommandeModelValidator>();
            services.AddTransient<IValidator<UserModel>, UserModelValidator>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestion de commande"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
