using GestionStock.Domain.Interface;
using GestionStock.Domain.Model;
using GestionStock.Domain.Services;
using GestionStock.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _context;
        public UserService(IUserRepository context)
        {
            _context = context;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var result = await _context.Authenticate(username, password);
           
            return result;
        }

        public async Task<User> Create(User user, string password)
        {
            await _context.Create(user, password);
            _context.SaveChanges();
    
            return user;
        }

        public void Delete(int id)
        {
            _context.Delete(id);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.GetAllUserAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.GetWithUsersByIdAsync(id);
        }

        public void Update(User user, string password )
        {
            _context.Update(user, password);
            _context.SaveChanges();
        }

    }
}
