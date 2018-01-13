using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoOfUs.Domain.Infrastructure;

namespace TwoOfUs.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
