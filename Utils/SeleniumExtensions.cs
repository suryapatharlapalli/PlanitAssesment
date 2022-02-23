using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace PlanitAssesment.Utils
{
    public class SeleniumExtensions
    {
        public static void SendKeys(IWebDriver driver, By by, string value)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void Click(IWebDriver driver, By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                element.Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void WaitUntilVisible(IWebDriver driver, By by, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            try
            {
                Thread.Sleep(GlobalConstants.Medium);
                //wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (NoSuchElementException e)
            {
                throw e;
            }
            catch (WebDriverTimeoutException e)
            {
                throw e;
            }
        }
        public static string GetText(IWebDriver driver, By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                return element.Text;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
