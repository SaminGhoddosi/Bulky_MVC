using Bulky.Domain.Entities;
using Ardalis.Specification;

namespace Bulky.Infra.Specification
{
    public class BookSpecification : Specification<Book>
    {
        public BookSpecification(int bookId)
        {
            Query.Include(x => x.Category);
            Query.Include(x => x.Authors);
            Query.Where(x => x.Id == bookId);
        }
    }
}