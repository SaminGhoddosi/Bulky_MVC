using Bulky.Domain.Interfaces.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Entities
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ISBN { get; set; }
        public string Author {  get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Author>? Authors { get; set; } = new List<Author>();
    }
}
