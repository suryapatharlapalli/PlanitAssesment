using System;
using PlanitAssesment.Utils;
using OpenQA.Selenium;
using NUnit.Framework;

namespace PlanitAssesment.Pages
{
    public class ShopPage
    {
        private SpecBase _SpecBase;

        //Locators
        private static string Link_Shop = "//li[@id='nav-shop']";
        private static string Button_FunnyCow = "//h4[text()='Funny Cow']/../p/a";
        private static string Button_StuffedFrog = "//h4[text()='Stuffed Frog']/../p/a";
        private static string Button_FluffyBunny = "//h4[text()='Fluffy Bunny']/../p/a";
        private static string Button_ValentineBear = "//h4[text()='Valentine Bear']/../p/a";
        private static string Link_Cart = "//li[@id='nav-cart']";
        private static string Text_CartMessage = " //p[@class='cart-msg']";
        public ShopPage(SpecBase _SpecBase)
        {
            this._SpecBase = _SpecBase;
        }
        public void NavigateToShopPage()
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Link_Shop), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Link_Shop));
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void ClikFunnyCow(int numberOfClicks)
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Button_FunnyCow), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                for (int i = 1; i <= numberOfClicks; i++)
                {
                    SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Button_FunnyCow));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void ClikFluffyBunny(int numberOfClicks)
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Button_FluffyBunny), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                for (int i = 1; i <= numberOfClicks; i++)
                {
                    SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Button_FluffyBunny));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void ClikStuffedFrog(int numberOfClicks)
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Button_StuffedFrog), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                for (int i = 1; i <= numberOfClicks; i++)
                {
                    SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Button_StuffedFrog));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void ClikValentineBear(int numberOfClicks)
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Button_ValentineBear), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                for (int i = 1; i <= numberOfClicks; i++)
                {
                    SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Button_ValentineBear));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void ClikCart()
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Link_Cart), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Link_Cart));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void VerifyCartMessage(string CartMessage)
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Text_CartMessage), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                string SuccessMessage = SeleniumExtensions.GetText(_SpecBase.driver, By.XPath(Text_CartMessage));
                Assert.AreEqual(CartMessage, SuccessMessage, "No Items are present in the cart");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void VerifySubtotal()
        {
            try
            {

                int itemCount = _SpecBase.driver.FindElements(By.XPath("//tr[@class='cart-item ng-scope']")).Count;
                for (int i = 1; i <= itemCount; i++)
                {
                    string itemPrice = SeleniumExtensions.GetText(_SpecBase.driver, By.XPath("//tr[@class='cart-item ng-scope'][" + i + "]//td[2]"));
                    string itemQuantity = _SpecBase.driver.FindElement(By.XPath("//tr[@class='cart-item ng-scope'][" + i + "]//td[3]/input")).GetAttribute("value");
                    string itemSubTotal = SeleniumExtensions.GetText(_SpecBase.driver, By.XPath("//tr[@class='cart-item ng-scope'][" + i + "]//td[4]"));
                    double expectedSubtotal = Convert.ToDouble(itemPrice.Substring(1)) * Convert.ToDouble(itemQuantity);
                    Assert.AreEqual(expectedSubtotal, Convert.ToDouble(itemSubTotal.Substring(1)), "Subtotal is wrong");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
