using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.UseCases.Authors.Queries.GetAuthorList
{
    public class GetAuthorListDTO
    {
        public Guid Id { get; init; }

        public string Nombre { get; init; } = null!;
    }
}
