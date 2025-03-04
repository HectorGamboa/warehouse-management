using AutoMapper;
using WH.Application.Dtos.Modules;
using WH.Domain.Entities;

namespace WH.Application.Mappings
{
    public class MenuMapping : Profile
    {
        public MenuMapping()
        {
            CreateMap<Module, ModuleResponseDto>()
                    .ForMember(x => x.MenuId, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.Item, x => x.MapFrom(y => y.Name))
                    .ForMember(x => x.Path, x => x.MapFrom(y => y.Url))
                    .ReverseMap();
        }
    }

}
