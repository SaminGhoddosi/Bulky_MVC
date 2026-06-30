using Bulky.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Application.AppModel
{
    public class BookAppModel : BaseAppModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryAppModel Category { get; set; }
        public ICollection<AuthorAppModel>? Authors { get; set; } = new List<AuthorAppModel>();
    }
}
