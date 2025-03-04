using AutoMapper;
using WH.Application.Dtos.UserRole;
using WH.Application.UseCases.UserRoles.Commands.CreateCommand;
using WH.Application.UseCases.UserRoles.Commands.UpdateCommand;
using WH.Domain.Entities;

namespace WH.Application.Mappings
{
    public class UserRoleMapping : Profile
    {
        public UserRoleMapping()
        {
            CreateMap<UserRole, UserRoleResponseDto>()
                .ForMember(x => x.UserRoleId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.User, y => y.MapFrom(x => x.User.FirstName + " " + x.User.LastName))
                .ForMember(x => x.Role, y => y.MapFrom(x => x.Role.Name))
                .ForMember(x => x.StateDescription, y => y.MapFrom(x => x.State == true ? "Enabled" : "Disabled"))
                .ReverseMap();

            CreateMap<UserRole, UserRoleByIdResponseDto>()
                .ForMember(x => x.UserRoleId, y => y.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateUserRoleCommand, UserRole>();
            CreateMap<UpdateUserRoleCommand, UserRole>();
        }
    }

}
