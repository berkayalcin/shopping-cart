# Simple E-Commerce Shopping Cart

# About
**The aim of the project is to show how the basket works and some rules for the e-commerce site.**

## Domains
## Catalog
#### Category
	Category class represents the product category. 
	It can include Title, Parent Category, and Child Categories.
#### Product
	Product class represents salable product. It contains the Price, Category and Title fields.
## Delivery

#### DeliveryCostCalculator
	The class used to calculate a shopping cart's delivery cost.
	Each delivery keeps unit rates and fixed shipping rates for the item.
	Calculates the shipping cost of the cart sent by the CalculateFor method.
## Discount
#### DiscountType
	It stores the type of discount. A discount can be either on a rate or amount basis.
#### Discount
	It is the base abstract discount class. Stores the discount type and amount.
	It applies a discount according to the type and amount of 
	discount it stores to the amount sent with the Apply Discount method.
	Returns how much discount will be applied to the amount sent by the Discount By Price method.
#### Campaign
	Campaigns are discounts that can be applied to categories.
	It stores the category, type of discount, 
	amount of discount and how many products there should be in the basket for this 
	discount to be applied.

#### Coupon
	Campaigns are discounts that can be applied to categories.
	It stores the category, type of discount, amount of discount and how many
	products there should be in the basket for this discount to be applied.
#### DiscountSatisfactions
	Checks whether the sent campaign or coupon code can be applied to the basket.
## Shopping Cart

#### ShoppingCartItem
	It is a shopping cart item. It contains product and quantity information.
#### ShoppingCart
	Shopping Cart stores Shopping Cart items, Applied coupons, Applied campaigns, per delivery cost, per product cost and fixed shipping cost.
	
	With the AddItem method, it adds the specified product and quantity to the shopping cart as a shopping cart item.
	
	It applies the campaigns or campaigns sent with the ApplyDiscounts method to the basket, if the conditions are met.
	
	ApplyCoupon method applies the coupon sent to the shopping cart, if the conditions are met.
	
	Returns the total discount amount of coupons with GetCouponDiscounts applied.
	
	GetCampaignDiscounts returns the total discount amount of campaigns applied.
	
	GetTotalAmountAfterDiscounts returns the amount after discounts are deducted from the basket total.
	
	Print prints information such as product name, category name, price, and discount for each of the products in the shopping cart.
	
	GetDeliveryCost returns the delivery cost.

#### Within the Shopping-Cart-XUnitTest project, there are tests of Category, Product, Shopping Cart, Shopping Cart Item and Shipping Cost Calculator classes.
