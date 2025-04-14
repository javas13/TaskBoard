using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.Core.Interfaces.Auth
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
