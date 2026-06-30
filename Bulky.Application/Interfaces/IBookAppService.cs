using Bulky.Application.AppModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bulky.Application.Interfaces
{
    public interface IBookAppService
    {
        Task<BookAppModel> GetBook(int id);
        Task<BookAppModel> CreateBook(BookAppModel book);
        Task<BookAppModel> UpdateBook(BookAppModel book);
        Task<BookAppModel> DeleteBook(BookAppModel book);
    }
}