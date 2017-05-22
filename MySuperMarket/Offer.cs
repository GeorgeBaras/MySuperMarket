using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    public class Offer : IOffer
    {
        public int NumberOfItemsForOfferToBeApplicable { get; set; }
        public decimal FixedAmountDiscount { get; set; }
        public decimal PercentageDiscount { get; set; }
        public Type ProductForWhichOfferIsApplicable { get; set; }

        public Offer(int numberOfItemsForOfferToBeApplicable, decimal fixedAmountDiscount, decimal percentageDiscount, Type productForWhichOfferIsApplicable ) {
            this.NumberOfItemsForOfferToBeApplicable = numberOfItemsForOfferToBeApplicable;
            this.FixedAmountDiscount = fixedAmountDiscount;
            this.PercentageDiscount = percentageDiscount;
            this.ProductForWhichOfferIsApplicable = productForWhichOfferIsApplicable;
        }
    }
}
