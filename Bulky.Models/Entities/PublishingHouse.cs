using Bulky.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Entities
{
    public class PublishingHouse : Entity
    {
        public string Name { get; set; } 
        public decimal? MarketValue { get; set; }
        public IEnumerable <Author>? Authors { get; set; }
    }
}
