using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        // Навигационные свойства
        public ICollection<ObjectiveEntity> Objectives { get; set; }
        public ICollection<ProjectEntity> Projects { get; set; }
        public ICollection<ProjectMemberEntity> ProjectMemberships { get; set; }
    }
}
