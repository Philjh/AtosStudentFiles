using Xunit;
using PizzaProject;

namespace TestProject
{
    public class CheckoutTests
    {
        Order order;
        Checkout checkout;

        public CheckoutTests()
        {
            order = new Order();
            checkout = new Checkout(new WeekdayDiscounts());
        }

        [Fact]
        public void No_Discount()
        {
            order.Pizzas.Add(new Pizza(Size.Small_10, Crust.Regular_2));

            PriceData priceData = checkout.GetBestPrice(order);

            Assert.Equal(12M, priceData.TotalPrice);
            Assert.Equal(DiscountPolicyName.None, priceData.DiscountPolicyName);
        }

        [Fact]
        public void Cheapest_Is_Free()
        {
            order.Pizzas.Add(new Pizza(Size.Small_10, Crust.Regular_2));
            order.Pizzas.Add(new Pizza(Size.Small_10, Crust.Regular_2));
            order.Pizzas.Add(new Pizza(Size.Medium_15, Crust.Thin_4));

            PriceData priceData = checkout.GetBestPrice(order);

            Assert.Equal(31M, priceData.TotalPrice);
            Assert.Equal(DiscountPolicyName.Cheapest_Is_Free, priceData.DiscountPolicyName);
        }

        [Fact]
        public void Five_Dollars_Off_Stuffed_Crust()
        {
            order.Pizzas.Add(new Pizza(Size.Small_10, Crust.Stuffed_3));

            PriceData priceData = checkout.GetBestPrice(order);

            Assert.Equal(8M, priceData.TotalPrice);
            Assert.Equal(DiscountPolicyName.Five_Dollars_Off_StuffedCrust, priceData.DiscountPolicyName);
        }

    }
}
