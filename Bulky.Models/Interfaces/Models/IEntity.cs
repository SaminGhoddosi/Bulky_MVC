using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Interfaces.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }

    public class Entity : IEntity<int>
    {
        public int Id { get; }
    }
}
