using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Books;

namespace Books.Application.Contracts.Repositories
{
    public interface IBooksRepository : Irepository<book>
    {
        Task<PaginationResponse<book>> GetPagedListAsync(
            PaginationRequest request,
            Guid? CategoryId,
            Guid? AutorId,
            CancellationToken cancellationToken = default);
    }
}