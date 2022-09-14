using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyQuery
{
    public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> technologies = await _programmingTechnologyRepository.GetListAsync(include:
                                              m => m.Include(c => c.ProgrammingLanguage),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
                ProgrammingTechnologyListModel mappedModel = _mapper.Map<ProgrammingTechnologyListModel>(technologies);
                return mappedModel;
            }
        }
    }
}
