using ApiServico.Controllers.Helpers;
using ApiServico.DataContexts;
using ApiServico.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.Controllers.Filters
{
    public class ChamadoFilterSet : IFilterSet<Chamado, ChamadoFilter>
    {
        public async Task<PagedResponse<Chamado>> Set(DbSet<Chamado> dbSet, ChamadoFilter filter)
        {
            var query = dbSet.AsQueryable();

            if (filter.Search is not null)
            {
                query = query.Where(x => x.Titulo.Contains(filter.Search));
            }

            if (filter.Situacao is not null)
            {
                query = query.Where(x => x.Status.Equals(filter.Situacao));
            }

            var (queryPaginated, response) = await Paginate<Chamado>.Set(query, filter);

            response.Data = await queryPaginated.ToListAsync();

            return response;
        }
    }
}
