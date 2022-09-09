using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Command.UpdateProgrammingLanguage
{
    public class UpdateProgramminLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgramminLanguageValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
