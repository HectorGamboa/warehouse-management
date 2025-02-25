using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;

namespace WH.Application.UseCases.Users.Queries.GetAllQuery
{

    public class GetAllUserQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<UserResponseDto>>> { }
}
