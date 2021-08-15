using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _serviceClient;
        public ClientController(IClientService serviceClient)
        {
            _serviceClient = serviceClient;
        }
        //[Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult<Client> AddClient(Client client)
        {
            try
            {
                var clientCreated = _serviceClient.CreateClient(client);
                return Ok(clientCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            var clients = _serviceClient.GetAllClients();
            return Ok(clients);
        }
        [HttpGet("{id}")]
        public ActionResult<Client>GetById(int id)
        {
            var client = _serviceClient.GetClientById(id);
            if (client==null)
            {
                return NotFound("Le client existe pas");
            }
            return Ok(client);
        }
    }
}
