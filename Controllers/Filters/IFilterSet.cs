using ApiServico.Controllers.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.Controllers.Filters
{
    public interface IFilterSet<TEntity, TFilter>
        where TEntity : class
        where TFilter : class
    {
        Task<PagedResponse<TEntity>> Set(DbSet<TEntity> dbSet, TFilter filter);
    }
}
