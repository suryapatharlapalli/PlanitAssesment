using System;
using PlanitAssesment.Utils;
using PlanitAssesment.Pages;
using TechTalk.SpecFlow;

namespace PlanitAssesment.StepDefinitions
{
    [Binding]
    public sealed class ShopSteps
    {
        private SpecBase _SpecBase;
        public ShopSteps(SpecBase _SpecBase)
        {
            this._SpecBase = _SpecBase;
        }
        [Given(@"User has navigated to Shop page")]
        public void GivenUserHasNavigatedToShopPage()
        {
            new ShopPage(_SpecBase).NavigateToShopPage();
        }

        [When(@"Click Cart button")]
        public void WhenClickCartButton()
        {
            new ShopPage(_SpecBase).ClikCart();
        }

        [Then(@"Verify items message in cart is ""(.*)""")]
        public void ThenVerifyItemsMessageInCartIs(string CartMessage)
        {
            new ShopPage(_SpecBase).VerifyCartMessage(CartMessage);
        }

        [When(@"User clicks ""(.*)"" times on Funny Cow")]
        public void WhenUserClicksTimesOnFunnyCow(int numberOfClicks)
        {
            new ShopPage(_SpecBase).ClikFunnyCow(numberOfClicks);
        }

        [When(@"User clicks ""(.*)"" time on Fluffy Bunny")]
        public void WhenUserClicksTimeOnFluffyBunny(int numberOfClicks)
        {
            new ShopPage(_SpecBase).ClikFluffyBunny(numberOfClicks);
        }

        [When(@"User clicks ""(.*)"" times on Stuffed Frog")]
        public void WhenUserClicksTimesOnStuffedFrog(int numberOfClicks)
        {
            new ShopPage(_SpecBase).ClikStuffedFrog(numberOfClicks);
        }

        [When(@"User clicks ""(.*)"" times on Fluffy Bunny")]
        public void WhenUserClicksTimesOnFluffyBunny(int numberOfClicks)
        {
            new ShopPage(_SpecBase).ClikFunnyCow(numberOfClicks);
        }

        [When(@"User clicks ""(.*)"" times on Valentine Bear")]
        public void WhenUserClicksTimesOnValentineBear(int numberOfClicks)
        {
            new ShopPage(_SpecBase).ClikValentineBear(numberOfClicks);
        }

        [Then(@"Verify SubTotal of items in the cart")]
        public void ThenVerifySubTotalOfItemsInTheCart()
        {
            new ShopPage(_SpecBase).VerifySubtotal();
        }

    }
}
