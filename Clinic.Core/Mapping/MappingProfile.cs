using AutoMapper;
using Clinic.Core.DTOs;
using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();    
            CreateMap<Patient, PatientDto>().ReverseMap();    
            CreateMap<Turn, TurnDto>().ReverseMap();
        }
    }
}
