using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    public class Vegetable : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Vegetable(string name, decimal price) {
            this.Name = Name;
            this.Price = price;
        }
    }
}
