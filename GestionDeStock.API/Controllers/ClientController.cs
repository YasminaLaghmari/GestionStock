using GestionDeStock.API.Applications.Commands;
using GestionDeStock.API.Applications.Queries;
using GestionDeStock.API.Models;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using MediatR;
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
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator,IClientService serviceClient)
        {
            _serviceClient = serviceClient;
            _mediator = mediator;
        }
        //[Authorize(Roles = "Manager")]
        [HttpPost]
        public async  Task<IActionResult> AddClient(ClientModel client)
        {
            IActionResult result = this.BadRequest();
            //try
            //{
            //    var clientCreated = _serviceClient.CreateClient(client);
            //    return Ok(clientCreated);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
           var item =  await this._mediator.Send(new AddClientCommand() { Item = client});
            if (item != null)
            {
                result = this.Ok(item);
            }

            return result;


        }
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            //var clients = _serviceClient.GetAllClients();
            var model = this._mediator.Send(new SelectAllClientQuery());
            return Ok(model);
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
