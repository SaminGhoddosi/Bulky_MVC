using Bulky.Application.AppModel;
using Bulky.Application.Interfaces;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using System.Threading.Tasks;

namespace Bulky.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryDomainService _domainService;

        public CategoryAppService(ICategoryDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<CategoryAppModel> GetCategory(int id)
        {
            var entity = await _domainService.GetByIdAsync(id);
            if (entity == null) return null;
            return new CategoryAppModel { Id = entity.Id, Name = entity.Name };
        }

        public async Task<CategoryAppModel> CreateCategory(CategoryAppModel categoryApp)
        {
            var entity = new Category { Name = categoryApp.Name };
            var created = await _domainService.AddAsync(entity);
            categoryApp.Id = created.Id;
            return categoryApp;
        }

        public async Task<CategoryAppModel> UpdateCategory(CategoryAppModel categoryApp)
        {
            var entity = new Category { Id = categoryApp.Id, Name = categoryApp.Name };
            var updated = await _domainService.UpdateAsync(entity);
            return categoryApp;
        }

        public async Task<CategoryAppModel> DeleteCategory(CategoryAppModel categoryApp)
        {
            var entity = new Category { Id = categoryApp.Id };
            await _domainService.DeleteAsync(entity);
            return categoryApp;
        }
    }
}