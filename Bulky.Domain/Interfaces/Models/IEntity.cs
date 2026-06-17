using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Interfaces.Models
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
