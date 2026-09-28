using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.UseCases.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListDTO
    {
        public Guid Id { get; init; }

        public string Nombre { get; init; } = null!;
    }
}
