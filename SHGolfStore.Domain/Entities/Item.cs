using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHGolfStore.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
