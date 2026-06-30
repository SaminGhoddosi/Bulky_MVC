using Bulky.Application.AppModel;
using Bulky.Application.Interfaces;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using System.Threading.Tasks;

namespace Bulky.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorDomainService _domainService;

        public AuthorAppService(IAuthorDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<AuthorAppModel> GetAuthor(int id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            if (entity == null) return null;
            return new AuthorAppModel
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                PublishHouseId = entity.PublishHouseId
            };
        }

        public async Task<AuthorAppModel> CreateAuthor(AuthorAppModel authorApp)
        {
            var entity = new Author
            {
                Name = authorApp.Name,
                BirthDate = authorApp.BirthDate,
                PublishHouseId = authorApp.PublishHouseId
            };

            var created = await _domainService.AddAsync(entity);
            authorApp.Id = created.Id;
            return authorApp;
        }

        public async Task<AuthorAppModel> UpdateAuthor(AuthorAppModel authorApp)
        {
            var entity = new Author
            {
                Id = authorApp.Id,
                Name = authorApp.Name,
                BirthDate = authorApp.BirthDate,
                PublishHouseId = authorApp.PublishHouseId
            };

            var updated = await _domainService.UpdateAsync(entity);
            return authorApp;
        }

        public async Task<AuthorAppModel> DeleteAuthor(AuthorAppModel authorApp)
        {
            var entity = new Author { Id = authorApp.Id };
            await _domainService.DeleteAsync(entity);
            return authorApp;
        }
    }
}