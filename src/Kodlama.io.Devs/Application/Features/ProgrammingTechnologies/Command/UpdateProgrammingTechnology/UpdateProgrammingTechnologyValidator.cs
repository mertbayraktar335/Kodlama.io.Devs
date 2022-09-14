using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
