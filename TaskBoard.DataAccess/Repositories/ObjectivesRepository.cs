using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Entities;
using TaskBoard.Core.Interfaces;

namespace TaskBoard.DataAccess.Repositories
{
    public class ObjectivesRepository: IObjectivesRepository
    {
        private readonly TaskBoardDbContext _context;
        public ObjectivesRepository(TaskBoardDbContext context) 
        { 
            _context = context;
        }

        public async Task<List <Objective>> Get()
        {
            var objectiveEntities = await _context.Objectives.AsNoTracking().ToListAsync();

            var objectives = objectiveEntities.Select(t => Objective.Create(t.Id, t.Name, t.Description, t.Type).objective)
                .ToList();

            return objectives;
        }

        public async Task<Guid> Create (Objective objective)
        {
            var objectiveEntity = new ObjectiveEntity
            {
                Id = objective.Id,
                Name = objective.Name,
                Description = objective.Description,
                Type = objective.Type,
            };
            await _context.Objectives.AddAsync(objectiveEntity);
            await _context.SaveChangesAsync();

            return objectiveEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description, string Type)
        {
            await _context.Objectives
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(o => o.Name, o => name)
                .SetProperty(o => o.Description, o => description)
                .SetProperty(o => o.Type, o => Type));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Objectives
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
