using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public string PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
        public bool isManager { get; set; }
        public bool isUser { get; set; }
        public bool isAgent { get; set; }
    }
}
