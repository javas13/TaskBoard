using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Application.Infrastructure;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Interfaces.Auth;
using TaskBoard.Core.Models;

namespace TaskBoard.Application.Services
{
    public class UsersService: IUsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        public UsersService(IPasswordHasher passwordHasher,
            IUsersRepository usersRepository,
            IJwtProvider jwtProvider) 
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task Register(string firstname, string surname, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), firstname, surname, hashedPassword, email);

            await _usersRepository.Create(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            if (user == null) 
            {
                return null;
            }
            else
            {
                var result = _passwordHasher.Verify(password, user.PasswordHash);

                if (result == false)
                {
                    return null;
                }
                else
                {
                    var token = _jwtProvider.GenerateToken(user);

                    return token;
                }
            }
        }
    }
}
