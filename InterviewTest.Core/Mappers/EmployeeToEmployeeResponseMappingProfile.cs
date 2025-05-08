using AutoMapper;
using InterviewTest.Core.DTO;
using InterviewTest.Infrastructure.Entities;

namespace InterviewTest.Core.Mappers;

public class EmployeeToEmployeeResponseMappingProfile : Profile
{
    public EmployeeToEmployeeResponseMappingProfile()
    {
        CreateMap<Employee, EmployeeWrapper>()
            .ForMember(dest => dest.Employee,
                opt => opt.MapFrom(src => src));

        CreateMap<Employee, EmployeeResponse>()
            .ForMember(dest => dest.ID,
                opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ManagerID,
                opt => opt.MapFrom(src => src.ManagerID))
            .ForMember(dest => dest.Employees,
                opt => opt.MapFrom(src => src.Employees));
    }
}