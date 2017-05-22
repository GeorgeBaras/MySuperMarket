using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySuperMarket;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class TestOfferRedeemer
    {
        [TestMethod]
        public void TestApplyOffersAndReturnTotalPrice() {
            OfferRedeemer offerRedeeemer = new OfferRedeemer();
            IBasket myBasket = createBasketWithUniqueProducts(); // 5 unique milks and 2 vegetables
            IOffer offerForDairy = buy2MilksGet20percentOffOffer();
            IOffer offerForVegetables = buyOneVegetableGet5Off();
            List<IOffer> offers = new List<IOffer>() {
                offerForDairy, offerForVegetables
            };

            decimal price = offerRedeeemer.applyOffersAndReturnTotalPrice(myBasket, offers);
            Assert.AreEqual(new decimal(168), price, "The total should be 2*24 + 3*30 + 2*15 = 168");
        }

        [TestMethod]
        public void TestΙsEnoughProductsInBasketForOfferToApply()
        {
            OfferRedeemer offerRedeeemer = new OfferRedeemer();
            IBasket myBasket = createBasket(4, 2); // 4 milks and 2 lettuces
            IOffer offer = buy2MilksGet20percentOffOffer();
            Assert.IsTrue(offerRedeeemer.isEnoughProductsInBasketForOfferToApply(myBasket, offer));
        }

        [TestMethod]
        public void TestTimesTheOfferMustApply()
        {
            OfferRedeemer offerRedeeemer = new OfferRedeemer();
            IBasket myBasket = createBasket(7, 2); // 7 milks and 2 lettuces
            IOffer offer = buy2MilksGet20percentOffOffer();

            Assert.AreEqual(3, offerRedeeemer.timesTheOfferMustApply(myBasket, offer), "The offer in this test should 3 times");
        }

        
        [TestMethod]
        public void TestApplyOfferToBasket()
        {
            OfferRedeemer offerRedeeemer = new OfferRedeemer();
            IBasket myBasket = createBasketWithUniqueProducts(); // 5 unique milks and 2 vegetables
            IOffer offer = buy2MilksGet20percentOffOffer();
            IBasket updatedBasket = offerRedeeemer.applyOfferAndGetBasket(myBasket, offer);
            Assert.AreEqual(new decimal(178), updatedBasket.getGrandTotal(), "The total should be 2*24 + 3*30 + 2*20 = 178");
        }




        // HELPERS
        private IBasket createBasketWithUniqueProducts()
        {
            Dairy milk = new Dairy("MilkOne", new decimal(30.0), new DateTime());
            Dairy milk1 = new Dairy("MilkOne", new decimal(30.0), new DateTime());
            Dairy milk2 = new Dairy("MilkOne", new decimal(30.0), new DateTime());
            Dairy milk3 = new Dairy("MilkOne", new decimal(30.0), new DateTime());
            Dairy milk4 = new Dairy("MilkOne", new decimal(30.0), new DateTime());

            Vegetable lettuce = new Vegetable("LettuceOne", new decimal(20.0));
            Vegetable cabbage = new Vegetable("LettuceOne", new decimal(20.0));

            List<IProduct> products = new List<IProduct>();

            products.Add(milk);
            products.Add(milk1);
            products.Add(milk2);
            products.Add(milk3);
            products.Add(milk4);
            products.Add(lettuce);
            products.Add(cabbage);
            IBasket basket = new Basket(products);
            return basket;
        }

        private IBasket createBasket(int numberOfMilks, int numberOfVegetables) {
            Dairy milk = new Dairy("MilkOne", new decimal(30.0),new DateTime());
            Vegetable lettuce = new Vegetable("LettuceOne", new decimal(20.0));

            List<IProduct> products = new List<IProduct>();

            
            for (int i = 0; i < numberOfMilks; i++)
            {
                products.Add(milk);
            }

            for (int i = 0; i < numberOfVegetables; i++)
            {
                products.Add(lettuce);
            }

            IBasket basket = new Basket(products);
            return basket;
        }

        private IOffer buy2MilksGet20percentOffOffer() {
            Dairy dairy = new Dairy("Test", new decimal(0.0), new DateTime());
            IOffer offer = new Offer(2,0,20, dairy.GetType());
            return offer;
        }

        private IOffer buyOneVegetableGet5Off() {
            Vegetable vegetable = new Vegetable("Test", new decimal(0.0));
            IOffer offer = new Offer(1, 5, 0, vegetable.GetType());
            return offer;
        }
    }
}
