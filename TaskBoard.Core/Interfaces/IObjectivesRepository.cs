using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.Core.Interfaces
{
    public interface IObjectivesRepository
    {
        Task<Guid> Create(Objective objective);
        Task<Guid> Update(Guid id, string name, string description, string Type);
        Task<List<Objective>> Get();
        Task<Guid> Delete(Guid id);
    }
}
