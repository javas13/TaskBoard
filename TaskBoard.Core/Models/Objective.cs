using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Core.Models
{
    public class Objective
    {
        public const int MAX_NAME_LENGTH = 250;

        private Objective(Guid id, string name, string description, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }

        public static (Objective objective, string Error) Create(Guid id, string name, string description, string type)
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

            var objective = new Objective(id, name, description, type);

            return (objective, error);
        }
    }
}
