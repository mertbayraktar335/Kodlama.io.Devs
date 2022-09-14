using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommand : IRequest<DeleteProgrammingTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand, DeleteProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<DeleteProgrammingTechnologyDto> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? progTech = await _programmingTechnologyRepository.GetAsync(x => x.Id == request.Id);
                
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(request.Id);

                ProgrammingTechnology deletedProgTech = await _programmingTechnologyRepository.DeleteAsync(progTech);


                DeleteProgrammingTechnologyDto deletedProgrammingTechnologyDto = _mapper.Map<DeleteProgrammingTechnologyDto>(deletedProgTech);
                return deletedProgrammingTechnologyDto;


            }
        }
    }
}
