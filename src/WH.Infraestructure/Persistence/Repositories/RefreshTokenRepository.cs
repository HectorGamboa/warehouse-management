using Microsoft.EntityFrameworkCore;
using WH.Application.Interfaces.Persistence;
using WH.Domain.Entities;
using WH.Infrastructure.Persistence.Context;

namespace WH.Infrastructure.Persistence.Repositories
{
    public class RefreshTokenRepository(ApplicationDbContext context) : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context = context;

        public void CreateToken(RefreshToken refreshToken)
        {
            _context.Add(refreshToken);
        }

        public async Task<RefreshToken> GetRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == refreshToken);

            return token!;
        }

        public async Task<bool> RevokeRefreshTokenAsync(string tokenRefresh)
        {
            await _context.RefreshTokens
                .Where(x => x.Token == tokenRefresh)
                .ExecuteDeleteAsync();
            return true;
        }
    }

}
