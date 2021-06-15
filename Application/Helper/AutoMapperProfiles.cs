using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationsErrorlog, GetAllErrorResponse>();
            //CreateMap<GetAllErrorResponse, ApplicationsErrorlog>();
        }
    }
}
