using Bulky.Domain.Interfaces.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Domain.Entities
{
    public class Category : Entity
    { 
        public string Name { get; set; }
    }
}