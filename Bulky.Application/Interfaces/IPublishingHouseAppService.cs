using Bulky.Application.AppModel;
using System.Threading.Tasks;

namespace Bulky.Application.Interfaces
{
    public interface IPublishingHouseAppService
    {
        Task<PublishingHouseAppModel> GetPublishingHouse(int id);
        Task<PublishingHouseAppModel> CreatePublishingHouse(PublishingHouseAppModel publishingHouse);
        Task<PublishingHouseAppModel> UpdatePublishingHouse(PublishingHouseAppModel publishingHouse);
        Task<PublishingHouseAppModel> DeletePublishingHouse(PublishingHouseAppModel publishingHouse);
    }
}