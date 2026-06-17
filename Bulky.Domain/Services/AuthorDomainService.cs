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
    public class AuthorDomainService : DomainService<Author>, IAuthorDomainService
    {
        private readonly IAuthorRepository _repository; 
        public AuthorDomainService(IAuthorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
