﻿using GestionStock.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetWithUsersByIdAsync(int id);
        public void SaveChanges();
        
    }
}