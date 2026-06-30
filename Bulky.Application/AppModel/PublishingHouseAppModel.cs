using Bulky.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Application.AppModel
{
    public class PublishingHouseAppModel
    {
        public string Name { get; set; }
        public decimal? MarketValue { get; set; }
        public ICollection<Author>? Authors { get; set; } = new List<Author>();
    }
}
