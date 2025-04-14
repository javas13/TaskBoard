using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Entities;

namespace TaskBoard.DataAccess.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly TaskBoardDbContext _context;
        public ProjectsRepository(TaskBoardDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(Project project)
        {
            var projectEntity = new ProjectEntity
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = DateTime.Now,
                OwnerId = project.OwnerId,
            };
            await _context.Projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();

            return projectEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Projects
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public Task<List<Project>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Update(Guid id, string name, string description, DateTime updatedAt)
        {
            await _context.Projects
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(o => o.Name, o => name)
                .SetProperty(o => o.Description, o => description)
                .SetProperty(o => o.UpdatedAt, o => updatedAt));

            return id;
        }
    }
}
