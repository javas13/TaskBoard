using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.Core.Interfaces
{
    public interface IProjectsService
    {
        Task<Guid> CreateProject(Project project);
        Task<Guid> DeleteProject(Guid id);
        Task<List<Objective>> GetAllProjects();
        Task<Guid> UpdateProject(Guid id, string name, string description, Guid ownerId, DateTime createdAt, DateTime updatedAt);
    }
}
