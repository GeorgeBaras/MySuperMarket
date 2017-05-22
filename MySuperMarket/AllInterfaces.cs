using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    public interface IProduct
    {
        string Name { get; set;}
        decimal Price { get; set; }
    }

    public interface IOffer
    {
        int NumberOfItemsForOfferToBeApplicable { get; set; }
        decimal FixedAmountDiscount { get; set; }
        decimal PercentageDiscount { get; set; }
        Type ProductForWhichOfferIsApplicable { get; set; }
    }

    public interface ISuperMarket
    {
        IOfferRedeemer OfferRedeemer { get; set; }
        Dictionary<Type, List<IProduct>> Stock { get; set; }
        void addProductsToStock(List<IProduct> products); // all products should be of the same kind or else an extra check is needed
        void addProduct(IProduct product);
        void removeProduct(IProduct product);
    }

    public interface IBasket
    {
        List<IProduct> Products { get; set; }
        void addProduct(IProduct product);
        void removeProduct(IProduct product);
        decimal getGrandTotal();
    }

    public interface IOfferRedeemer
    {
        decimal applyOffersAndReturnTotalPrice(IBasket basket, List<IOffer> offers);
    }
}
