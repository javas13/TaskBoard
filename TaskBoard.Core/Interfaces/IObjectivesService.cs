using TaskBoard.Core.Models;

namespace TaskBoard.Core.Interfaces
{
    public interface IObjectivesService
    {
        Task<Guid> CreateObjective(Objective objective);
        Task<Guid> DeleteObjective(Guid id);
        Task<List<Objective>> GetAllObjectives();
        Task<Guid> UpdateObjective(Guid id, string name, string description, string type);
    }
}