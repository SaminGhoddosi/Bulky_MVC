using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using Bulky.Domain.Interfaces.Repository;
using Bulky.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain
{
    public class DomainAutoConfig
    {
        private readonly ILogger<DomainAutoConfig> _logger;

        public DomainAutoConfig(ILogger<DomainAutoConfig> logger)
        {
            _logger = logger;
        }

        public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthorDomainService, AuthorDomainService>();
            services.AddScoped<IBookDomainService, BookDomainService>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<IPublishingHouseDomainService, PublishingHouseDomainService>();

            return services;
        }
    }
}
