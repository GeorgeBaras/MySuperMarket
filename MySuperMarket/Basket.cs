using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    public class Basket : IBasket
    {
        public List<IProduct> Products { get; set; }

        public Basket(List<IProduct> products)
        {
            this.Products = products;
        }


        public Basket() {
            this.Products = new List<IProduct>();
        }

        public void addProduct(IProduct product)
        {
            this.Products.Add(product);
        }

        public void removeProduct(IProduct product)
        {
            this.Products.Remove(product);
        }

        public decimal getGrandTotal() {
            decimal total = new decimal(0);
            foreach (var item in this.Products)
            {
                total += item.Price;
            }
            return total;
        }
    }

    public class ProductPriceComparer : IComparer<IProduct>
    {
        public int Compare(IProduct x, IProduct y)
        {
            if (x.Price > y.Price)
            {
                return 1;
            }
            else if (x.Price == y.Price) {
                return 0;
            }
            return -1;
        }
    }
}
