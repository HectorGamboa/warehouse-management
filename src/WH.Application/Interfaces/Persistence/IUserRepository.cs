using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Domain.Entities;

namespace WH.Application.Interfaces.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UserByEmailAsync(string email);
    }
}
