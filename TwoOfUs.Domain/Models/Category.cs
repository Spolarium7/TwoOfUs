using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoOfUs.Domain.Infrastructure;

namespace TwoOfUs.Domain.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
