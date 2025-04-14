using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.DataAccess.Entities
{
    public class ProjectEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Навигационные свойства
        public UserEntity Owner { get; set; }
        public ICollection<ObjectiveEntity> Objectives { get; set; }
        public ICollection<ProjectMemberEntity> Members { get; set; }
    }
}
