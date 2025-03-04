using AutoMapper;
using WH.Application.Dtos.Commons;
using WH.Application.Dtos.Users;
using WH.Application.UseCases.Users.Commands.CreateCommand;
using WH.Application.UseCases.Users.Commands.UpdateCommand;
using WH.Domain.Entities;

namespace WH.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserResponseDto>()
          .ForMember(x => x.UserId, y => y
              .MapFrom(x => x.Id))
          .ForMember(x => x.StateDescription, y => y
              .MapFrom(x => x.State == true ? "Enabled" : "Disabled"))
          .ReverseMap();


            CreateMap<User, UserByIdResponseDto>()
                .ForMember(x => x.UserId, y => y
                    .MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            CreateMap<User, SelectResponseDto>()
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Description, x => x.MapFrom(y => y.FirstName + " " + y.LastName))
                .ReverseMap();
        }
    }

}
