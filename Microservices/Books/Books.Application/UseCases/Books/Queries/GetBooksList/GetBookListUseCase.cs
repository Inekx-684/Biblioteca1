using Books.Application.Contracts.Repositories;
using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Books;

namespace Books.Application.UseCases.Books.Queries.GetBooksList
{
    public class GetBookListUseCase
        : IRequestHandler<GetBookListQuery, PaginationResponse<BookListItemDTO>>
    {
        private readonly IBooksRepository _repository;

        public GetBookListUseCase(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<BookListItemDTO>> Handle(
            GetBookListQuery query)
        {
            PaginationRequest pagination = query.Pagination;

            PaginationResponse<book> response =
                await _repository.GetPagedListAsync(
                    pagination,
                    query.CategoryId,
                    query.AutorId);

            List<BookListItemDTO> items =
                response.Items
                        .Select(b => b.ToListItemDTO())
                        .ToList();

            return PaginationResponse<BookListItemDTO>.Create(
                items,
                response.TotalCount,
                pagination);
        }
    }
}