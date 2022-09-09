using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Command.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? progLang = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);

                await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(request.Id);

                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(progLang);
                
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(updatedProgrammingLanguageDto.Name);
                
                
                
                return updatedProgrammingLanguageDto;
            }
        }
    }
}
