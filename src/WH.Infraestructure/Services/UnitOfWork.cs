using WH.Application.Interfaces.Persistence;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;
using WH.Infrastructure.Persistence.Context;
using WH.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace WH.Infrastructure.Services
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IUserRepository _user = null!;
        private readonly IModuleRepository _menu = null!;
        private readonly IGenericRepository<Role> _role = null!;
        private readonly IGenericRepository<UserRole> _userRole = null!;
        private readonly IPermissionRepository _permission = null!;
        private readonly IRefreshTokenRepository _refreshToken = null!;
        private readonly IGenericRepository<Bitacora> _bitacora = null!;

        public IUserRepository User => _user ?? new UserRepository(_context);
        public IModuleRepository Menu => _menu ?? new ModuleRepository(_context);
        public IGenericRepository<Role> Role => _role ?? new GenericRepository<Role>(_context);
        public IGenericRepository<UserRole> UserRole => _userRole ?? new GenericRepository<UserRole>(_context);
        public IPermissionRepository Permission => _permission ?? new PermissionRepository(_context);
        public IRefreshTokenRepository RefreshToken => _refreshToken ?? new RefreshTokenRepository(_context);
        public IGenericRepository<Bitacora> Bitacora => _bitacora ?? new GenericRepository<Bitacora>(_context);
        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
