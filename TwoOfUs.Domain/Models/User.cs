using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoOfUs.Domain.Infrastructure;
using TwoOfUs.Domain.Models.Enums;

namespace TwoOfUs.Domain.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
