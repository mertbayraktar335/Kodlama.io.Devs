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

namespace Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdateProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdateProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;
            private readonly IMapper _mapper;

            public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules, IMapper mapper)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
                _mapper = mapper;
            }

            public async Task<UpdateProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? progTech = await _programmingTechnologyRepository.GetAsync(x => x.Id == request.Id);

                await _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(request.Id);

                ProgrammingTechnology mappedProgTech = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology updatedProgTech = await _programmingTechnologyRepository.AddAsync(mappedProgTech);
                IPaginate<ProgrammingTechnology> technology = await _programmingTechnologyRepository.GetListAsync(
                    c => c.Id == updatedProgTech.Id,
                    include: p => p.Include(c => c.ProgrammingLanguage)
                );
               UpdateProgrammingTechnologyDto updateProgrammingTechnologyDto = _mapper.Map<UpdateProgrammingTechnologyDto>(updatedProgTech);
                return updateProgrammingTechnologyDto;
            }
        }
    }
}
