using Books.Application.UseCases.Books.Queries.GetBooksList;
using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Books.Application.UseCases.Authors.Queries.GetAuthorList;
using Books.Application.UseCases.Categories.Queries.GetCategoriesList;

namespace Books.Application
{
    public static class ApplicationServicesRegistry
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Mediator
            //services.AddSingleton<IMediator, SimpleMediator>();//Las dependencias tienen una unica instancia
            services.AddScoped<IMediator, SimpleMediator>();//El ciclo va por cada metodo superior, con los mismos datos dentro del scope
                                                            // services.AddTransient<IMediator, SimpleMediator>();//el ciclo de vida va a ser exclusivamente por llamada

            //Use cases
            //book
            services.AddScoped<IRequestHandler<GetBookListQuery, PaginationResponse<BookListItemDTO>>, GetBookListUseCase>();
            //Autor
            services.AddScoped<IRequestHandler<GetAuthorListQuery, PaginationResponse<GetAuthorListDTO>>, GetAuthorListUseCase>();
            //Category
            services.AddScoped<IRequestHandler<GetCategoriesListQuery, PaginationResponse<GetCategoriesListDTO>>, GetCategoriesListUseCase>();

            return services;
        }

        
    }
}
