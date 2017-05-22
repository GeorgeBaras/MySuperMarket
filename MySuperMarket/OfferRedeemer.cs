using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    public class OfferRedeemer : IOfferRedeemer
    {
        public decimal applyOffersAndReturnTotalPrice(IBasket basket, List<IOffer> offers)
        {
            basket.Products.Sort(new ProductPriceComparer());
            foreach (var offer in offers)
            {
                basket = getUpdatedBasketAfterApplyingOffer(basket, offer);
            }
            return basket.getGrandTotal();
        }



        // The following helper methods should be private but it has been marked as public to facilitate unit testing
        public IBasket getUpdatedBasketAfterApplyingOffer(IBasket basket, IOffer offer)
        {
            if (isEnoughProductsInBasketForOfferToApply(basket, offer)) {
                // find how many times the offer should apply
                // apply the offer by reducing the price of any item the offer is applicable for
                return applyOfferAndGetBasket(basket, offer);
            }
            return basket;
        }

        public IBasket applyOfferAndGetBasket(IBasket basket, IOffer offer) {
            int timesApplyingTheOffer = timesTheOfferMustApply(basket, offer);
            foreach (var product in basket.Products)
            {
                if (product.GetType() == (offer.ProductForWhichOfferIsApplicable) && timesApplyingTheOffer>0) {
                    // Apply the discounts from the offer
                    product.Price -= product.Price*(offer.PercentageDiscount/100);
                    product.Price -= offer.FixedAmountDiscount;
                    timesApplyingTheOffer--;
                }

            }
            return basket;
        }

        public int timesTheOfferMustApply(IBasket basket, IOffer offer) {
            // get number of relevant products
            int numberOfApplicableProducts = 0;

            foreach (var product in basket.Products)
            {
                if (product.GetType() == (offer.ProductForWhichOfferIsApplicable))
                {
                    numberOfApplicableProducts++;
                }
            }
            //return the div of the following
            return numberOfApplicableProducts / offer.NumberOfItemsForOfferToBeApplicable;
        }

        // This is NOT really needed but it helped in the initial testing kai thn afhsa etsi gia plaka..exei code repetition ekei sta if pou einai code smell..
        public Boolean isEnoughProductsInBasketForOfferToApply(IBasket basket, IOffer offer) {
            int numberOfApplicableProducts = 0;
            
            foreach (var product in basket.Products)
            {
                if (product.GetType()==(offer.ProductForWhichOfferIsApplicable)) {
                    numberOfApplicableProducts++;
                    if (numberOfApplicableProducts >= offer.NumberOfItemsForOfferToBeApplicable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        
    }
}
