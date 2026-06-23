using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.IServices;
using Bulky.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Services
{
    public class BookDomainService : DomainService<Book>, IBookDomainService
    {
        private readonly IBookRepository _repository;
        public BookDomainService(IBookRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
