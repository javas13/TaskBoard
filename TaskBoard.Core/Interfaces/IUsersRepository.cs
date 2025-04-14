using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<Guid> Create(User user);
        Task<User> GetByEmail(string email);
    }
}
