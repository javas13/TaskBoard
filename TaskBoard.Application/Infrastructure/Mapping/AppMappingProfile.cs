using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Entities;

namespace TaskBoard.Application.Infrastructure.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserEntity, User>();
        }
    }
}
