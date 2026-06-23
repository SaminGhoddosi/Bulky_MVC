using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using Bulky.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Services
{
    public class PublishingHouseDomainService : DomainService<PublishingHouse>, IPublishingHouseDomainService
    {
        private readonly IPublishHouseRepository _repository;

        public PublishingHouseDomainService(IPublishHouseRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
