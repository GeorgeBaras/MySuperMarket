using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Create some dairy products
            Dairy milk = new Dairy("MilkOne", new decimal(30.0), new DateTime());
            Dairy milk1 = new Dairy("MilkTwo", new decimal(30.0), new DateTime());
            Dairy milk2 = new Dairy("MilkThree", new decimal(40.0), new DateTime());
            Dairy milk3 = new Dairy("MilkFour", new decimal(30.0), new DateTime());
            Dairy milk4 = new Dairy("MilkFive", new decimal(30.0), new DateTime());
            // Create some vegetables
            Vegetable tomato1 = new Vegetable("tomato1", new decimal(10.0));
            Vegetable tomato2 = new Vegetable("tomato2", new decimal(10.0));
            Vegetable tomato3 = new Vegetable("tomato3", new decimal(15.0));

            // All together they cost 4*30 + 40 + 2*10 + 15 = 195

            // Lets create some offers
            
            // Buy two milk get 10% off *** It will enforce the discount on the first items it will find in the basket
            // this happens because we have made all the milk products as dairy..there should be more subclasses for them, 
            // just changing the price isn't really enough in real life 
            IOffer offerForTwoMilks = new Offer(2, 0, 10, milk.GetType());

            // Buy two vegetables, get 5 off
            IOffer offerForVegetables = new Offer(2, 5, 0, tomato1.GetType());
            // Create a list for the two Offers
            List<IOffer> offers = new List<IOffer>() {
                offerForTwoMilks,
                offerForVegetables
            };


            // Create a basket with all the items
            IBasket myBasket = new Basket();

            myBasket.addProduct(milk);
            myBasket.addProduct(milk1);
            myBasket.addProduct(milk2);
            myBasket.addProduct(milk3);
            myBasket.addProduct(milk4);
            myBasket.addProduct(tomato1);
            myBasket.addProduct(tomato2);
            myBasket.addProduct(tomato3);

            // Create an OfferRedeemer like the one the Supermarket would have to apply the offers to the basket
            IOfferRedeemer offerRedeemer = new OfferRedeemer();
            // We are expecting to get 10% off the the first two milks, 2*3 and a fixed 5 for the first vegetable == 11 off, 195-11=184,final price
            Console.WriteLine(offerRedeemer.applyOffersAndReturnTotalPrice(myBasket, offers));
            Console.Read();
        }
    }
}
