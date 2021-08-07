using GestionStock.Domain.Interface;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Service
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _repository;
        public ClientService(IRepository<Client>repository)
        {
            _repository = repository;
        }

        public Client CreateClient(Client newClient)
        {
            var client= _repository.Add(newClient);
            _repository.SaveChanges();
            return client;
        }

        public void DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _repository.All();
        }

        public Client GetClientById(int id)
        {
            return _repository.Get(id);
        }

        public Client UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
