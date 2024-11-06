using AutoMapper;
using Clinic.API.Model;
using Clinic.Entities;

namespace Clinic.API.Mapping
{
    public class ApiMappingProfile : Profile
    {

        public ApiMappingProfile()
        {

            CreateMap<DoctorPostModel, Doctor>().ReverseMap();
            CreateMap<PatientPostModel, Patient>().ReverseMap();
            CreateMap<TurnPostModel, Turn>().ReverseMap();
        }
    }
}
