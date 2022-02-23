Feature: Shop
	
Scenario: Verify the Cart items
	Given User has navigated to Shop page
	When User clicks "2" times on Funny Cow
	And User clicks "1" times on Fluffy Bunny
	And Click Cart button
	Then Verify items message in cart is "There are 3 items in your cart, you can Checkout or carry on Shopping."

Scenario: Verify the subtotal price of items in the cart
	Given User has navigated to Shop page
	When User clicks "2" times on Stuffed Frog
	And User clicks "5" times on Fluffy Bunny
	And User clicks "3" times on Valentine Bear
	And Click Cart button
	Then Verify SubTotal of items in the cart