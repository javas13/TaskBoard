using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Repositories;

namespace TaskBoard.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }
        public async Task<Guid> CreateProject(Project project)
        {
            return await _projectsRepository.Create(project);
        }

        public async Task<Guid> DeleteProject(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Objective>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UpdateProject(Guid id, string name, string description, Guid ownerId, DateTime createdAt, DateTime updatedAt)
        {
            throw new NotImplementedException();
        }
    }
}
