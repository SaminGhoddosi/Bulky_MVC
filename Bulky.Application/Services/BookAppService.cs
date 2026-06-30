using Bulky.Application.AppModel;
using Bulky.Application.Interfaces;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using System.Threading.Tasks;

namespace Bulky.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookDomainService _domainService;

        public BookAppService(IBookDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<BookAppModel> GetBook(int id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            if (entity == null) return null;
            return new BookAppModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ISBN = entity.ISBN,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                CategoryId = entity.CategoryId
            };
        }

        public async Task<BookAppModel> CreateBook(BookAppModel bookApp)
        {
            var entity = new Book
            {
                Name = bookApp.Name,
                Description = bookApp.Description,
                ISBN = bookApp.ISBN,
                Price = bookApp.Price,
                ImageUrl = bookApp.ImageUrl,
                CategoryId = bookApp.CategoryId
            };

            var created = await _domainService.AddAsync(entity);
            bookApp.Id = created.Id;
            return bookApp;
        }

        public async Task<BookAppModel> UpdateBook(BookAppModel bookApp)
        {
            var entity = new Book
            {
                Id = bookApp.Id,
                Name = bookApp.Name,
                Description = bookApp.Description,
                ISBN = bookApp.ISBN,
                Price = bookApp.Price,
                ImageUrl = bookApp.ImageUrl,
                CategoryId = bookApp.CategoryId
            };

            var updated = await _domainService.UpdateAsync(entity);
            return bookApp;
        }

        public async Task<BookAppModel> DeleteBook(BookAppModel bookApp)
        {
            var entity = new Book { Id = bookApp.Id };
            await _domainService.DeleteAsync(entity);
            return bookApp;
        }
    }
}