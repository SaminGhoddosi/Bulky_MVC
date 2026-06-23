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
    public class CategoryDomainService : DomainService<Category>, ICategoryDomainService
    {
        private readonly ICategoryRepository _repository;
        public CategoryDomainService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
