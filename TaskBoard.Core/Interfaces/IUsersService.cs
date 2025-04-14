using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Core.Interfaces
{
    public interface IUsersService
    {
        Task Register(string firstname, string surname, string email, string password);
        Task<string> Login(string email, string password);
    }
}
