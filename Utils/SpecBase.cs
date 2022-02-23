using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Support.Extensions;


namespace PlanitAssesment.Utils
{
    public class SpecBase
    {
        public IWebDriver driver { get; set; }
        public static readonly string _Url = ConfigurationManager.AppSettings["JupiterUrl"];
        public static readonly string _BrowserType = ConfigurationManager.AppSettings["BrowserType"];
        public static readonly string _FilePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + @"../../../").FullName+"\\PlanitAssesment\\TestData\\ContactDetails.json";     
        public Dictionary<string, string> TestDataDetails { get; set; }
        public static string ScreenshotDirectory { get; set; }

        public IList<IWebElement> elements;
        public void OpenBrowser(string browser)
        {
            if (browser.Equals("Chrome"))
            {
                driver = new ChromeDriver();               
            }
            else if (browser.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }
        }
        public void NavigateToUrl()
        {

            try
            {
                driver.Navigate().GoToUrl(_Url);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalConstants.Long);
            }
            catch (Exception)
            {

                throw new InvalidCastException();
            }
        }
        public void TakeWindowScreenShot(string path, ScreenshotImageFormat fileFormat)
        {
            driver.TakeScreenshot().SaveAsFile(path, fileFormat);
        }

        /// <summary>Takes a screenshot</summary>        
        /// Updated By :
        public void TakeScreenshot(string ScenarioName)
        {
            ScreenshotDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + @"../../../").FullName + "\\Results\\Reports\\" + "\\" + ScenarioName;
            TakeWindowScreenShot(ScreenshotDirectory, ScreenshotImageFormat.Png);

        }

        /// <summary>Deletes screenshot directory</summary>        
        /// Updated By :
        public static void DeleteScreenshotDirectory()
        {
            string dir = string.Empty;
            dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + @"../../../").FullName;
            dir = dir + "\\Results\\";
            Console.WriteLine("directory: " + dir);
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }
    }
}
