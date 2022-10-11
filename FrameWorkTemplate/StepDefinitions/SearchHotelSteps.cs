using FrameWorkTemplate.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkTemplate.StepDefinitions
{
    [Binding]
    public class SearchHotelSteps
    {
        SearchHotelPage searchHotelPage;
       public SearchHotelSteps()
        {
            searchHotelPage = new SearchHotelPage();
        }

        [Given(@"I am already logged into the application")]
        public void GivenIAmAlreadyLoggedIntoTheApplication()
        {
            searchHotelPage.ValidateSearchHotelPage();
        }

        [When(@"I enter the below search credentials")]
        public void WhenIEnterTheBelowSearchCredentials(Table table)
        {
            searchHotelPage.EnterSearchCriterias(table);
        }


        [When(@"I click on the Search button")]
        public void WhenIClickOnTheSearchButton()
        {
            searchHotelPage.ClickSearchButton();
        }

        [Then(@"the select hotel page should return")]
        public void ThenTheSelectHotelPageShouldReturn()
        {

        }

        [Then(@"the button ""([^""]*)"" displayed at the top of the page")]
        public void ThenTheButtonDisplayedAtTheTopOfThePage(string text)
        {
            searchHotelPage.ValidateItinaryPage();
        }
    }
}
