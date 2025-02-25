using Microsoft.EntityFrameworkCore;
using WH.Application.Interfaces.Persistence;
using WH.Domain.Entities;
using WH.Infrastructure.Persistence.Context;

namespace WH.Infrastructure.Persistence.Repositories
{
    public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> UserByEmailAsync(string email)
        {
            var user = await _context.Users
                     .AsNoTracking()
                     .FirstOrDefaultAsync(x => x.Email.Equals(email) &&
                                          x.State == "1" &&
                                          x.AuditDeleteUser == null &&
                                          x.AuditDeleteDate == null);

            return user!;
        }
    }
}
