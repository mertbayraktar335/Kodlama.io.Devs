using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologiesRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologiesRepository)
        {
            _programmingTechnologiesRepository = programmingTechnologiesRepository;
        }
        public async Task ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologiesRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Langugage name exists.");
        }
        public async Task ProgrammingTechnologyShouldExistWhenRequested(int id)
        {
            ProgrammingTechnology? pTech = await _programmingTechnologiesRepository.GetAsync(b => b.Id == id);
            if (pTech == null) throw new BusinessException("Requested Programming Language doesn't exist");
        }
    }
}
