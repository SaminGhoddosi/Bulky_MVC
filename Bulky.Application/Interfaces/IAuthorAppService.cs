using Bulky.Application.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Application.Interfaces
{
    public interface IAuthorAppService
    {
        Task<AuthorAppModel> GetAuthor(int id);
        Task<AuthorAppModel> CreateAuthor(AuthorAppModel author);
        Task<AuthorAppModel> UpdateAuthor(AuthorAppModel author);
        Task<AuthorAppModel> DeleteAuthor(AuthorAppModel author);

    }
}
