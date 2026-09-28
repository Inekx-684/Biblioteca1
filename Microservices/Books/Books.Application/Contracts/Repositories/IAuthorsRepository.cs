using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Author;

namespace Books.Application.Contracts.Repositories
{
    public interface IAuthorsRepository : Irepository<Author>
    {
        Task<PaginationResponse<Author>> GetPagedListAsync(
            PaginationRequest request,
            CancellationToken cancellationToken = default);
    }
}