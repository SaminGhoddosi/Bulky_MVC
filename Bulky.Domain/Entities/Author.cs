using Bulky.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
        public int PublishHouseId { get; set; }
        public PublishingHouse? PublishingHouse { get; set; }
    }
}
