using Bulky.DataAccess.Repository;
using Bulky.DataAcess.Data;
using Bulky.Domain.Entities;
using Bulky.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Infra.Repository
{
    public class PublishingHouseRepository : RepositoryBase<PublishingHouse>, IPublishHouseRepository
    {
        public PublishingHouseRepository(AppDbContext db) : base(db) 
        {
        }
    }
}
