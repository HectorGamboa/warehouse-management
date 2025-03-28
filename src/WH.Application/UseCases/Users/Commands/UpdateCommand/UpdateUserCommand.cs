﻿using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.Users.Commands.UpdateCommand
{
    public class UpdateUserCommand : IRequest<BaseResponse<bool>>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? State { get; set; }
    }

}
