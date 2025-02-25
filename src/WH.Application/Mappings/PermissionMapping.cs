using AutoMapper;
using WH.Application.Dtos.Permissions;
using WH.Domain.Entities;

namespace WH.Application.Mappings
{
    public class PermissionMapping : Profile
    {
        public PermissionMapping()
        {
            CreateMap<Permission, PermissionsResponseDto>()
                    .ForMember(x => x.PermissionId, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.PermissionName, x => x.MapFrom(y => y.Name))
                    .ForMember(x => x.PermissionDescription, x => x.MapFrom(y => y.Description))
                    .ReverseMap();
        }
    }
}
