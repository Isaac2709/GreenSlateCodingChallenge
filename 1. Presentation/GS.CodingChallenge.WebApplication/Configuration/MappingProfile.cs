using AutoMapper;
using GS.CodingChallenge.Domain.Models;
using GS.CodingChallenge.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.CodingChallenge.WebApplication.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Project, ProjectViewModel>().ReverseMap();
            CreateMap<UserProject, UserProjectViewModel>().ReverseMap();
        }
    }
}
