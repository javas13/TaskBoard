using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.DataAccess.Entities
{
    public class ObjectiveEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CreatorId { get; set; } // Кто создал задачу
        public string Status { get; set; } // "ToDo", "InProgress", "Done"
        public string Priority { get; set; } // "Low", "Medium", "High"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Навигационные свойства
        public ProjectEntity Project { get; set; }
        public UserEntity Creator { get; set; }
    }
}
