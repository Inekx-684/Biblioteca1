using System;
using System.Collections.Generic;
using System.Text;
using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;


namespace Books.Application.UseCases.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<PaginationResponse<GetAuthorListDTO>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
    }
}
