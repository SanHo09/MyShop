using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.DataAccessor.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category category { get; set; }
        public virtual List<Order> Orders { get; set;}
    }
}