using Bulky.Application.AppModel;
using Bulky.Application.Interfaces;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using System.Threading.Tasks;

namespace Bulky.Application.Services
{
    public class PublishingHouseAppService : IPublishingHouseAppService
    {
        private readonly IPublishingHouseDomainService _domainService;

        public PublishingHouseAppService(IPublishingHouseDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<PublishingHouseAppModel> GetPublishingHouse(int id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            if (entity == null) return null;
            return new PublishingHouseAppModel { Name = entity.Name, MarketValue = entity.MarketValue };
        }

        public async Task<PublishingHouseAppModel> CreatePublishingHouse(PublishingHouseAppModel publishingHouseApp)
        {
            var entity = new PublishingHouse { Name = publishingHouseApp.Name, MarketValue = publishingHouseApp.MarketValue };
            var created = await _domainService.AddAsync(entity);
            publishingHouseApp.Authors = entity.Authors;
            return publishingHouseApp;
        }

        public async Task<PublishingHouseAppModel> UpdatePublishingHouse(PublishingHouseAppModel publishingHouseApp)
        {
            var entity = new PublishingHouse { Name = publishingHouseApp.Name, MarketValue = publishingHouseApp.MarketValue, Authors = publishingHouseApp.Authors };
            var updated = await _domainService.UpdateAsync(entity);
            return publishingHouseApp;
        }

        public async Task<PublishingHouseAppModel> DeletePublishingHouse(PublishingHouseAppModel publishingHouseApp)
        {
            var entity = new PublishingHouse { Name = publishingHouseApp.Name };
            await _domainService.DeleteAsync(entity);
            return publishingHouseApp;
        }
    }
}