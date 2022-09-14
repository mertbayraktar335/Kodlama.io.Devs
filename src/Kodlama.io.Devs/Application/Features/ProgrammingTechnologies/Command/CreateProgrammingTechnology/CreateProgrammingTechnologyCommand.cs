using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguages.Command.ProgrammingTechnologies.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreateProgrammingTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreateProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologiesRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologiesRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<CreateProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingTechnology mappedProgTech = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology createdProgTech = await _programmingTechnologyRepository.AddAsync(mappedProgTech);
                IPaginate<ProgrammingTechnology> technology = await _programmingTechnologyRepository.GetListAsync(
                    c => c.Id == createdProgTech.Id,
                    include: p => p.Include(c => c.ProgrammingLanguage)
                );
                CreateProgrammingTechnologyDto createProgrammingTechnologyDto = _mapper.Map<CreateProgrammingTechnologyDto>(createdProgTech);
                return createProgrammingTechnologyDto;
            }
        }
    }
}
