using Bulky.DataAcess.Data;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.Repository;

namespace Bulky.DataAccess.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext db) : base(db)
        {
        }
    }
}
