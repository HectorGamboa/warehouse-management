using System.Data;
using WH.Application.Interfaces.Persistence;
using WH.Domain.Entities;

namespace WH.Application.Interfaces.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IMenuRepository Menu { get; }
        IGenericRepository<Role> Role { get; }
        IGenericRepository<UserRole> UserRole { get; }
        IPermissionRepository Permission { get; }
        Task SaveChangesAsync();
        IDbTransaction BeginTransaction();
    }
}
