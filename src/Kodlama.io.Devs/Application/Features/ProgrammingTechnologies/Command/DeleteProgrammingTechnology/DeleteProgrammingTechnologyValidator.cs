using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyValidator : AbstractValidator<DeleteProgrammingTechnologyCommand>
    {
        public DeleteProgrammingTechnologyValidator()
        {
           
                RuleFor(c => c.Id).NotEmpty();
            
        }
    }
}
