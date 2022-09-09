using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }

        public ProgrammingLanguage()
        {
        }

        public ProgrammingLanguage(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }
}
