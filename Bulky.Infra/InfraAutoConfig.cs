using Bulky.DataAccess.Repository;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.Repository;
using Bulky.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Infra
{
    public class InfraAutoConfig
    {
        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublishHouseRepository, PublishingHouseRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        } 
    }
}
