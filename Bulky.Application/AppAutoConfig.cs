using Bulky.Application.Interfaces;
using Bulky.Application.Services;
using Bulky.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Bulky.Application
{
    public class AppAutoConfig
    {
        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorAppService, AuthorAppService>();
            services.AddScoped<IBookAppService, BookAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IPublishingHouseAppService, PublishingHouseAppService>();
            return services;
        }
    }
}
