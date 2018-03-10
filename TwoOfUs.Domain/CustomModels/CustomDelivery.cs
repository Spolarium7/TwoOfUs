using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoOfUs.Domain.CustomModels
{
    public class CustomDelivery
    {
        public DateTime Date { get; set; }

        public List<CustomDeliveryItem> Items { get; set; }
    }

    public class CustomDeliveryItem
    {
        public Guid? MaterialId { get; set; }
        
        public string MaterialName { get; set; }

        public decimal Quantity { get; set; }
    }
}
