using Books.Application.Contracts.Repositories;
using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Author;
using Books.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence.Repositories
{
    public class AuthorsRepository
        : Repository<Author>, IAuthorsRepository
    {
        private readonly DataContext _context;

        public AuthorsRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Author>> GetPagedListAsync(
            PaginationRequest request,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Author> query = _context.Set<Author>()
                                               .AsNoTracking()
                                               .OrderBy(a => a.Nombre.Valor);

            return await query.ToPagedListAsync(
                request,
                cancellationToken);
        }
    }
}