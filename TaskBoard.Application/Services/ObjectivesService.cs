using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;

namespace TaskBoard.Application.Services
{
    public class ObjectivesService : IObjectivesService
    {
        private readonly IObjectivesRepository _objectivesRepository;
        public ObjectivesService(IObjectivesRepository objectiveRepository)
        {
            _objectivesRepository = objectiveRepository;
        }

        public async Task<List<Objective>> GetAllObjectives()
        {
            return await _objectivesRepository.Get();
        }

        public async Task<Guid> CreateObjective(Objective objective)
        {
            return await _objectivesRepository.Create(objective);
        }

        public async Task<Guid> UpdateObjective(Guid id, string name, string description, string type)
        {
            return await _objectivesRepository.Update(id, name, description, type);
        }

        public async Task<Guid> DeleteObjective(Guid id)
        {
            return await _objectivesRepository.Delete(id);
        }
    }
}
