using Books.Application.Contracts.Repositories;
using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Author;

namespace Books.Application.UseCases.Authors.Queries.GetAuthorList
{
    public class GetAuthorListUseCase
        : IRequestHandler<GetAuthorListQuery, PaginationResponse<GetAuthorListDTO>>
    {
        private readonly IAuthorsRepository _repository;

        public GetAuthorListUseCase(IAuthorsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<GetAuthorListDTO>> Handle(
            GetAuthorListQuery query)
        {
            PaginationRequest pagination = query.Pagination;

            PaginationResponse<Author> response =
                await _repository.GetPagedListAsync(pagination);

            List<GetAuthorListDTO> items =
                response.Items
                        .Select(a => a.ToListItemDTO())
                        .ToList();

            return PaginationResponse<GetAuthorListDTO>.Create(
                items,
                response.TotalCount,
                pagination);
        }
    }
}