using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Core.Models
{
    public class Project
    {
        public const int MAX_NAME_LENGTH = 250;
        public Project(Guid id, string name, string description, Guid ownerId) 
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerId = ownerId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public static (Project project, string Error) Create(Guid id, string name, string description, Guid ownerId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Name can not be empty";
            }
            else if (name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be longer than 250 symbols";
            }

            var project = new Project(id, name, description, ownerId);

            return (project, error);
        }
    }
}
