using AutoMapper;
using WH.Application.Dtos.Modules;
using WH.Domain.Entities;

namespace WH.Application.Mappings
{
    public class ModuleMapping : Profile
    {
        public ModuleMapping()
        {
            CreateMap<Module, ModuleResponseDto>()
                    .ForMember(x => x.MenuId, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.Item, x => x.MapFrom(y => y.Name))
                    .ForMember(x => x.Route, x => x.MapFrom(y => y.Route))
                    .ReverseMap();
        }
    }

}
