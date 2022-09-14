using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingTechnology()
        {
        }

        public ProgrammingTechnology(int id, int programmingLanguageId, string name, ProgrammingLanguage? programmingLanguage)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            ProgrammingLanguage = programmingLanguage;
        }
    }
}
