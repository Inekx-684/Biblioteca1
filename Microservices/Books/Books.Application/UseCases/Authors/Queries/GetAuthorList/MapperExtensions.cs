using System;
using System.Collections.Generic;
using System.Text;
using Books.Domain.Entities.Author;

namespace Books.Application.UseCases.Authors.Queries.GetAuthorList
{
    public static class MapperExtensions
    {
        public static GetAuthorListDTO ToListItemDTO(
            this Author authorEntity)
        {
            return new GetAuthorListDTO
            {
                Id = authorEntity.Id,
                Nombre = authorEntity.Nombre.Valor
            };
        }
    }
}
