using Bulky.Domain.Entities;
using Ardalis.Specification;

namespace Bulky.Infra.Specification
{
    public class AuthorSpecification : Specification<Author>
    {
        public AuthorSpecification(int authorId)
        {
            Query.Include(x => x.Books).ThenInclude(x => x.Category);
            Query.Include(x => x.PublishingHouse);
            Query.Where(x => x.Id == authorId);
        }
    }
}
