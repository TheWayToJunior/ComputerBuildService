using AutoMapper;
using ComputerBuildService.BL.Models;
using ComputerBuildService.BL.Models.Requests;
using ComputerBuildService.DAL.Entitys;
using System.Linq;

namespace ComputerBuildService.Server.Profiles
{
    public class ApplicatinProfile : Profile
    {
        public ApplicatinProfile()
        {
            CreateMap<HardwareItemEntity, HardwareItemResponse>()
                 .ForMember(model => model.PropertysItems, opt => opt
                    .MapFrom(entity => entity.PropertysItems
                        .Select(p => p.Property)
                        .ToList()))
                 .ForMember(model => model.Manufacturer, opt => opt
                    .MapFrom(entity => entity.Manufacturer.Name))
                 .ForMember(model => model.HardwareType, opt => opt
                    .MapFrom(entity => entity.HardwareType.TypeName));

            CreateMap<CompatibilityPropertyEntity, CompatibilityPropertyResponse>();
            CreateMap<CompatibilityPropertyRequest, CompatibilityPropertyEntity>();
        }
    }
}
