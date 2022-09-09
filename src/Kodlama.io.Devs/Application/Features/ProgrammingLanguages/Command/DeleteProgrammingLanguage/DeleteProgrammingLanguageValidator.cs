using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Command.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
