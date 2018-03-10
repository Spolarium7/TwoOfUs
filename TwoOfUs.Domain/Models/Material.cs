using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoOfUs.Domain.Infrastructure;

namespace TwoOfUs.Domain.Models
{
    public class Material : BaseModel
    {
        public string Name { get; set; }

        public string UOM { get; set; } //Unit of Measure

        public decimal Quantity { get; set; } 
    }
}
