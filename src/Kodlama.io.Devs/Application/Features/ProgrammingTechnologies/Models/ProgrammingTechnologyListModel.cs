using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingTechnologies.Dtos;

namespace Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel
    {
        public IList<ProgrammingTechnologyListDto> Items { get; set; }
    }
}
