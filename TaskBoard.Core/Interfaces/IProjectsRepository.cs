using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.Core.Interfaces
{
    public interface IProjectsRepository
    {
        Task<Guid> Create(Project project);
        Task<Guid> Update(Guid id, string name, string description, DateTime updatedAt);
        Task<List<Project>> Get();
        Task<Guid> Delete(Guid id);
    }
}
