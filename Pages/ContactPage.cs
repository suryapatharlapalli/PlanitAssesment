using System;
using PlanitAssesment.Utils;
using OpenQA.Selenium;
using NUnit.Framework;

namespace PlanitAssesment.Pages
{

    public class ContactPage
    {
        private SpecBase _SpecBase;
        //Locators
        private static string Input_ForeName = "//input[@id='forename']";
        private static string Input_Email = "//input[@id='email']";
        private static string TextArea_Message = "//textarea[@id='message']";
        private static string Link_Contact = "//li[@id='nav-contact']";
        private static string Button_Submit = "//a[@class='btn-contact btn btn-primary']";
        private static string Text_ContactSuccessMessage = " //div[@class='alert alert-success']";
        public ContactPage(SpecBase _SpecBase)
        {
            this._SpecBase = _SpecBase;
        }
        public void NavigateToContactPage()
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Link_Contact), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Link_Contact));
            }
            catch (Exception e)
            {

                throw e;
            }
        }	
        public void FillContactDetails(string TestCaseName)
        {
            try
            {
                _SpecBase.TestDataDetails = new DataHelper().ReadTestDataFromJSONFile(SpecBase._FilePath, TestCaseName);
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Input_ForeName), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                SeleniumExtensions.SendKeys(_SpecBase.driver, By.XPath(Input_ForeName), _SpecBase.TestDataDetails["ForeName"]);
                SeleniumExtensions.SendKeys(_SpecBase.driver, By.XPath(Input_Email), _SpecBase.TestDataDetails["Email"]);
                SeleniumExtensions.SendKeys(_SpecBase.driver, By.XPath(TextArea_Message), _SpecBase.TestDataDetails["Message"]);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SubmitContact()
        {
            try
            {               
                SeleniumExtensions.Click(_SpecBase.driver, By.XPath(Button_Submit));
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Link_Contact), TimeSpan.FromMilliseconds(GlobalConstants.Long));
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void VerifyContactSuccessMessage(string ContactMessage)
        {
            try
            {
                SeleniumExtensions.WaitUntilVisible(_SpecBase.driver, By.XPath(Text_ContactSuccessMessage), TimeSpan.FromMilliseconds(GlobalConstants.Medium));
                string SuccessMessage=SeleniumExtensions.GetText(_SpecBase.driver, By.XPath(Text_ContactSuccessMessage));
                Assert.AreEqual(ContactMessage, SuccessMessage,"Contact has not been submitted");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
