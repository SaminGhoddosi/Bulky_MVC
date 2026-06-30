using Bulky.Application.AppModel;
using System.Threading.Tasks;

namespace Bulky.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<CategoryAppModel> GetCategory(int id);
        Task<CategoryAppModel> CreateCategory(CategoryAppModel category);
        Task<CategoryAppModel> UpdateCategory(CategoryAppModel category);
        Task<CategoryAppModel> DeleteCategory(CategoryAppModel category);
    }
}