using PlanitAssesment.Utils;
using PlanitAssesment.Pages;
using TechTalk.SpecFlow;

namespace PlanitAssesment.StepDefinitions
{
    [Binding]
    public sealed class ContactSteps
    {
        private SpecBase _SpecBase;
        public ContactSteps(SpecBase _SpecBase)
        {
            this._SpecBase = _SpecBase;
        }

     
        [Given(@"User has navigated to Contact page")]
        public void GivenUserHasNavigatedToContactPage()
        {
            new ContactPage(_SpecBase).NavigateToContactPage();
        }

        [When(@"User fill mandatory fields ""(.*)""")]
        public void WhenUserFillMandatoryFields(string Details)
        {
            new ContactPage(_SpecBase).FillContactDetails(Details);
        }

        [When(@"Click Submit button")]
        public void WhenClickSubmitButton()
        {
            new ContactPage(_SpecBase).SubmitContact();
        }

        [Then(@"Verify Contact Message is ""(.*)""")]
        public void ThenVerifyContactMessageIs(string SuccessMessage)
        {
            new ContactPage(_SpecBase).VerifyContactSuccessMessage(SuccessMessage);
        }


    }
}
