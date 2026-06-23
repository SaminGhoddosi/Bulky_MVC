using Bulky.Domain.Entities;
using Ardalis.Specification;

namespace Bulky.Infra.Specification
{
    public class PublishingHouseSpecification : Specification<PublishingHouse>
    {
        public PublishingHouseSpecification(int publishHouseId)
        {
            Query.Include(x => x.Authors).ThenInclude(x => x.Books).Where(x => x.Id == publishHouseId);
        }
    }
}
