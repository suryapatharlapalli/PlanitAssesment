using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Runtime.CompilerServices;
namespace PlanitAssesment.Utils
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());
        public static ExtentReports Instance { get { return _lazy.Value; } }

        [ThreadStatic]
        private static ExtentTest _parentTest;

        [ThreadStatic]
        private static ExtentTest _scenarioTest;

        [ThreadStatic]
        private static ExtentTest _childTest;

        private ExtentManager()
        {
        }

        static ExtentManager()
        {
            string directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + @"../../../").FullName;
            directory = directory + "\\Results\\";
            DirectoryInfo path = Directory.GetParent(directory).CreateSubdirectory("Reports");
            var htmlReporter = new ExtentHtmlReporter(path + "\\Extent.html");
            Instance.AddSystemInfo("Environment :", "Test");
            Instance.AddSystemInfo("Username :", Environment.UserName);
            Instance.AddSystemInfo("Machine :", Environment.MachineName + ", " + Environment.OSVersion);
            Instance.AddSystemInfo("Network :", Environment.UserDomainName);
            Instance.AddSystemInfo("Browser :", SpecBase._BrowserType);
            Instance.AddSystemInfo("TimeZone :", TimeZone.CurrentTimeZone.StandardName);

            Instance.AttachReporter(htmlReporter);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {

            _parentTest = Instance.CreateTest(testName, description);
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateScenario(string testName, string[] tags, string description = null)
        {
            _scenarioTest = _parentTest.CreateNode<Scenario>(testName, description);
            _scenarioTest.AssignCategory(tags);
            return _scenarioTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateSteps(string stepType, string testName, bool status, string message = null, string imgName = null, string description = null)
        {
            if (status)
            {
                if (stepType == "Given")
                    _childTest = _scenarioTest.CreateNode<Given>(testName, description).Pass("");
                else if (stepType == "When")
                    _childTest = _scenarioTest.CreateNode<When>(testName, description).Pass("");
                else if (stepType == "Then")
                    _childTest = _scenarioTest.CreateNode<Then>(testName, description).Pass("");
                else if (stepType == "And")
                    _childTest = _scenarioTest.CreateNode<And>(testName, description).Pass("");
            }
            else if (!status)
            {
                if (stepType == "Given")
                    _childTest = _scenarioTest.CreateNode<Given>(testName).Fail(message).AddScreenCaptureFromPath(@".\" + imgName);
                else if (stepType == "When")
                    _childTest = _scenarioTest.CreateNode<When>(testName).Fail(message).AddScreenCaptureFromPath(@".\" + imgName);
                else if (stepType == "Then")
                    _childTest = _scenarioTest.CreateNode<Then>(testName).Fail(message).AddScreenCaptureFromPath(@".\" + imgName);
                else if (stepType == "And")
                    _childTest = _scenarioTest.CreateNode<And>(testName).Fail(message).AddScreenCaptureFromPath(@".\" + imgName);
            }
            return _childTest;
        }
    }
}
