﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Roles;
using WH.Application.Interfaces.Services;
using Helper = WH.Application.Helpers.Helpers;

namespace WH.Application.UseCases.Roles.Queries.GetAllQuery
{
    public class GetAllRoleHandler : IRequestHandler<GetAllRoleQuery, BaseResponse<IEnumerable<RoleResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;

        public GetAllRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery orderingQuery)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;
        }
        public async Task<BaseResponse<IEnumerable<RoleResponseDto>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<RoleResponseDto>>();

            try
            {
                var roles = _unitOfWork.Role.GetAllQueryable();

                if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
                {
                    switch (request.NumFilter)
                    {
                        case 1:
                            roles = roles.Where(x => x.Name.Contains(request.TextFilter));
                            break;
                        case 2:
                            roles = roles.Where(x => x.Description!.Contains(request.TextFilter));
                            break;
                    }
                }

                if (request.StateFilter is not null)
                {
                    var stateFilter = Helper.SplitStateFilter(request.StateFilter);
                    roles = roles.Where(x => stateFilter.Contains(x.State.ToString()));
                }

                if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
                {
                    roles = roles.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate) &&
                        x.AuditCreateDate <= Convert.ToDateTime(request.EndDate).AddDays(1));
                }

                request.Sort ??= "Id";

                var items = await _orderingQuery.Ordering(request, roles).ToListAsync(cancellationToken);

                response.IsSuccess = true;
                response.TotalRecords = await roles.CountAsync(cancellationToken);
                response.Data = _mapper.Map<IEnumerable<RoleResponseDto>>(items);
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
