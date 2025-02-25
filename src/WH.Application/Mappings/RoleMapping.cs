using AutoMapper;
using WH.Application.Dtos.Commons;
using WH.Application.Dtos.Roles;
using WH.Application.UseCases.Roles.Commands.CreateCommand;
using WH.Application.UseCases.Roles.Commands.UpdateCommand;
using WH.Domain.Entities;

namespace WH.Application.Mappings
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleResponseDto>()
                .ForMember(x => x.RoleId, y => y
                    .MapFrom(x => x.Id))
                .ForMember(x => x.StateDescription, y => y
                    .MapFrom(x => x.State == "1" ? "Enabled" : "Disabled"))
                .ReverseMap();

            CreateMap<Role, RoleByIdResponseDto>()
                .ForMember(x => x.RoleId, y => y
                    .MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();

            CreateMap<Role, SelectResponseDto>()
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Name))
                .ReverseMap();
        }
    }

}
