using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.ExceptionService;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Entities;

namespace TaskBoard.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TaskBoardDbContext _context;
        private readonly IMapper _mapper;
        public UsersRepository(TaskBoardDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Surname = user.Surname,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (userEntity == null) 
            {
                return null;
            }
            else
            {
                return _mapper.Map<User>(userEntity);
            }
        }
    }
}
