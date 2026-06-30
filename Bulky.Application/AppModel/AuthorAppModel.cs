using Bulky.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Application.AppModel
{
    public class AuthorAppModel : BaseAppModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<BookAppModel>? Books { get; set; } = new List<BookAppModel>();
        public int PublishHouseId { get; set; }
        public PublishingHouseAppModel? PublishingHouse { get; set; }
    }
}
