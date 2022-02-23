using PlanitAssesment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace PlanitAssesment.Hooks
{
    [Binding]
    public sealed class GeneralSpecHooks
    {
        private SpecBase _SpecBase;
        public GeneralSpecHooks(SpecBase _SpecBase)
        {
            this._SpecBase = _SpecBase;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            SpecBase.DeleteScreenshotDirectory();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            ExtentManager.CreateParentTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            _SpecBase.OpenBrowser(SpecBase._BrowserType);
            _SpecBase.NavigateToUrl();

            ExtentManager.CreateScenario(context.ScenarioInfo.Title, context.ScenarioInfo.Tags);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext context)
        {
            var stepType = context.StepContext.StepInfo.StepDefinitionType.ToString();
            if (context.TestError == null)
            {
                ExtentManager.CreateSteps(stepType, context.StepContext.StepInfo.Text, true);
            }
            else if (context.TestError != null)
            {
                string imgName = context.ScenarioInfo.Title;
                _SpecBase.TakeScreenshot(imgName);
                ExtentManager.CreateSteps(stepType, context.StepContext.StepInfo.Text, false, context.TestError.Message, imgName);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _SpecBase.driver.Quit();

        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            ExtentManager.Instance.Flush();
        }
    }
}
