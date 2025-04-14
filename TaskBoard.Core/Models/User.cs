using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Core.Models
{
    public class User
    {
        private User(Guid id, string firstname, string surname, string passwordHash, string email)
        {
            Id = id;
            Firstname = firstname;
            Surname = surname;
            PasswordHash = passwordHash;
            Email = email;
        } 

        public Guid Id { get; set; }
        public string Firstname { get; private set; }
        public string Surname { get; private set; } 
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        public static User Create(Guid id, string firstname, string surname, string passwordHash, string email)
        {
            return new User(id, firstname, surname, passwordHash, email);
        }
    }
}
