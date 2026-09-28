using Books.Application.Utilities.Mediator.Pagination;
using Microsoft.EntityFrameworkCore;
using Books.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Persistence.Extensions
{
    internal static class QueryableExtensions
    {
        public static async Task<PaginationResponse<T>> ToPagedListAsync<T>(
            this IQueryable<T> queryable,
            PaginationRequest request,
            CancellationToken cancellationToken = default)
        {
            int totalCount = await queryable.CountAsync(cancellationToken);

            List<T> items = await queryable
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return PaginationResponse<T>.Create(
                items,
                totalCount,
                request);
        }
    }
}

