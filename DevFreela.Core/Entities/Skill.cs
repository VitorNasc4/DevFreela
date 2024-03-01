using System;

namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
