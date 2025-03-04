using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;
using WH.Application.Interfaces.Services;
using Helper = WH.Application.Helpers.Helpers;

namespace WH.Application.UseCases.Users.Queries.GetAllQuery
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, BaseResponse<IEnumerable<UserResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;

        public GetAllUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;
        }

        public async Task<BaseResponse<IEnumerable<UserResponseDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<UserResponseDto>>();

            try
            {
                var users = _unitOfWork.User.GetAllQueryable();

                if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
                {
                    switch (request.NumFilter)
                    {
                        case 1:
                            users = users.Where(x => x.FirstName.Contains(request.TextFilter));
                            break;
                        case 2:
                            users = users.Where(x => x.LastName.Contains(request.TextFilter));
                            break;
                    }
                }

                if (request.StateFilter is not null)
                {
                    var stateFilter = Helper.SplitStateFilter(request.StateFilter);
                    users = users.Where(x => stateFilter.Contains(x.State.ToString()));
                }

                if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
                {
                    users = users.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate) &&
                        x.AuditCreateDate <= Convert.ToDateTime(request.EndDate).AddDays(1));
                }

                request.Sort ??= "Id";

                var items = await _orderingQuery.Ordering(request, users).ToListAsync(cancellationToken);

                response.IsSuccess = true;
                response.TotalRecords = await users.CountAsync(cancellationToken);
                response.Data = _mapper.Map<IEnumerable<UserResponseDto>>(items)?? [];
                response.Message = "Consulta existosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
