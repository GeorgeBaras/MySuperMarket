using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    public class Dairy : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Dairy(string name, decimal price, DateTime expirationDate) {
            this.Name = name;
            this.Price = price;
            this.ExpirationDate = expirationDate;
        }
    }
}
