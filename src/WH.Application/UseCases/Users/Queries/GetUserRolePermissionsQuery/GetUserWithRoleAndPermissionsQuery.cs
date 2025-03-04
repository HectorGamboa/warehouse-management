using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;

namespace WH.Application.UseCases.Users.Queries.GetUserRolePermissionsQuery
{
    public class GetUserWithRoleAndPermissionsQuery : IRequest<BaseResponse<UserWithRoleAndPermissionsDto>>
    {
        public int UserId { get; set; }
    }

}
