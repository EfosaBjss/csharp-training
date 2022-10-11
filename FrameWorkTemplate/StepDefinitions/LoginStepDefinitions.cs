using FrameWorkTemplate.PageObjects;
using OpenQA.Selenium;

namespace FrameWorkTemplate.StepDefinitions 
{
    [Binding]
    public class LoginStepDefinitions
    {
        LoginPage loginPage;
        public LoginStepDefinitions()
        {
            
            loginPage = new LoginPage();
            
        }

        [Given(@"I navigate to the adactin website")]
        public void GivenINavigateToTheAdactinWebsite()
        {
            loginPage.LaunchUrl();
          
        }

        [Given(@"I enter my username and password")]
        public void GivenIEnterMyUsernameAndPassword()
        {
            loginPage.EnterUserNameAndPassword();
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see the hotel search page")]
        public void ThenIShouldSeeTheHotelSearchPage()
        {
            loginPage.ValidateSearchPage();
        }

    }
}