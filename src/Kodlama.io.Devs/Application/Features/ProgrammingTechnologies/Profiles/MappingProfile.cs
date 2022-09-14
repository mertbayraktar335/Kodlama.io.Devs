using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Command.ProgrammingTechnologies.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<ProgrammingTechnology>,ProgrammingTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>().ReverseMap();
        }
    }
}
