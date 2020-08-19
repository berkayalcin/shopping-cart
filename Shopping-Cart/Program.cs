using Shopping_Cart.Domains.Catalog.Concrete;
using Shopping_Cart.Domains.Discount.Concrete;
using Shopping_Cart.Domains.ShoppingCart.Concrete;
using System;

namespace Shopping_Cart
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart shoppingCart = new ShoppingCart(1, 1);
            Category shoes = new Category("Shoes");
            Category nikeShoes = new Category("Nike Shoes", shoes);
            Category adidasShoes = new Category("Adidas Shoes", shoes);

            Product nikeAir = new Product("Nike Air", 100, nikeShoes);
            Product nikeZoom = new Product("Nike Zoom", 200, nikeShoes);
            Product adidasShoe = new Product("Adidas", 100, adidasShoes);

            Campaign nikeShoesCampaign = new Campaign(nikeShoes, 10, 1, Domains.Discount.Enums.DiscountType.Rate);
            Coupon newUserCoupon = new Coupon(100, Domains.Discount.Enums.DiscountType.Amount, 100);


            shoppingCart.AddItem(adidasShoe, 1);
            shoppingCart.AddItem(nikeAir, 1);
            shoppingCart.AddItem(nikeZoom, 2);
            shoppingCart.ApplyDiscounts(nikeShoesCampaign);
            shoppingCart.ApplyCoupon(newUserCoupon);
            shoppingCart.Print();
            Console.ReadKey();
        }
    }
}
