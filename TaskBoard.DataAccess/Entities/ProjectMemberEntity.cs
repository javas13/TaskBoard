using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Core.Models;

namespace TaskBoard.DataAccess.Entities
{
    public class ProjectMemberEntity
    {
        public int Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string Role { get; set; } // "Owner", "Admin", "Member"
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        // Навигационные свойства
        public ProjectEntity Project { get; set; }
        public UserEntity User { get; set; }
    }
}
