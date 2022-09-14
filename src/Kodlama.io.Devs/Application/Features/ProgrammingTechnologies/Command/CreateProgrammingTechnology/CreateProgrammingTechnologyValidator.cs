using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Command.ProgrammingTechnologies.CreateProgrammingTechnology;
using FluentValidation;

namespace Application.Features.ProgrammingTechnologies.Command.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreateProgrammingTechnologyValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
