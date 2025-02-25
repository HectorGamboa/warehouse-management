using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;

namespace WH.Application.UseCases.Users.Queries.GetByIdQuery
{
    public class GetUserByIdQuery : IRequest<BaseResponse<UserByIdResponseDto>>
    {
        public int UserId { get; set; }
    }
}
