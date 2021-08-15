using GestionDeStock.API.Models;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using GestionStock.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly ICommandeService _serviceCommande;
        public CommandeController(ICommandeService serviceCommande)
        {
            _serviceCommande = serviceCommande;
        }
        
       
        
    }
}
