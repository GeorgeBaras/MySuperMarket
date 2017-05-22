using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    class SingleSuperMarket : ISuperMarket
    {
        public Dictionary<Type, List<IProduct>> Stock { get; set; }

        public List<IBasket> baskets { get; set; }

        public IOfferRedeemer OfferRedeemer { get; set; }

        private static SingleSuperMarket instance = new SingleSuperMarket();

        private SingleSuperMarket() {
            //TODO create the initial stock that our supermarket would have, optional though, we can add stock using the add methods
            this.baskets = new List<IBasket>();
        }

        public static SingleSuperMarket getInstance() {
            return instance;
        }

        public void addProduct(IProduct product)
        {
            if (Stock.ContainsKey(product.GetType())) {
                Stock[product.GetType()].Add(product);
            }
            // Add the new product to the stock
            List<IProduct> products = new List<IProduct>() {
                product
            };
            Stock.Add(product.GetType(),products);
        }

        public void addProductsToStock(List<IProduct> products)
        {
            if (Stock.ContainsKey(products.First().GetType()))
            {
                Stock[products.First().GetType()].AddRange(products);
            }
            // Add the new product to the stock
            
            Stock.Add(products.First().GetType(), products);
        }

        public void removeProduct(IProduct product)
        {
            foreach (var productCategory in Stock)
            {

                foreach (var item in productCategory.Value)
                {
                    if (item.Equals(product)) {
                        productCategory.Value.Remove(product);
                    }
                }
            }
        }
    }
}
