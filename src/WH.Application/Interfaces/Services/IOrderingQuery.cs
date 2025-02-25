using WH.Application.Commons.Bases;

namespace WH.Application.Interfaces.Services
{
    public interface IOrderingQuery
    {
        IQueryable<T> Ordering<T>(BasePagination request, IQueryable<T> queryable) where T : class;
    }
}
