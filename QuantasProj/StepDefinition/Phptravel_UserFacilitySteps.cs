using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using QuantasProj.Extensions;
using QuantasProj.Pageobjects;


namespace QuantasProj.StepDefinition
{
    [Binding]
    public sealed class Phptravel_UserFacilitySteps
    {
        IWebDriver driver;
        searchHotelDetails searchhoteldetails;

        [Given(@"I am in the PHPTRAVELS site as a new user")]
        public void GivenIaminthePHPTRAVELSsiteasanewuser()
        {
            searchhoteldetails = new searchHotelDetails();
            Assert.IsTrue(searchhoteldetails.NavigateToPHPTravelsSite(), ScenarioContext.Current.StepContext.StepInfo.Text, "The website was loaded unsuccessfully");
        }

        [When(@"I choose to book a hotel of my choice as HotelName:""(.*)"" StartDate:""(.*)"" EndDate:""(.*)"" NumberOfAdults:""(.*)"" NumberOfChildren:""(.*)""")]
        public void WhenIChooseToBookAHotelOfMyChoiceAsHotelNameStartDateEndDateNumberOfAdultsNumberOfChildren(string hotelName, string startDate, string endDate, int adultCount, int childCount)
        {
            Assert.IsTrue(searchhoteldetails.AddHotelDetails(hotelName, startDate, endDate, adultCount, childCount), ScenarioContext.Current.StepContext.StepInfo.Text, "Select Hotel action failed");
        }
        
        [When(@"I click on search")]
        public void WhenIClickOnSearch()
        {
            Assert.IsTrue(searchhoteldetails.clickSearch(), ScenarioContext.Current.StepContext.StepInfo.Text, "Search Hotel action failed");
        }
        
        [Then(@"I reach the details page of the Rendezvous hotel and view the available room details")]
        public void ThenIReachTheDetailsPageOfTheRendezvousHotelAndViewTheAvailableRoomDetails()
        {
            Assert.IsTrue(searchhoteldetails.HotelDetailsPanelDisplayed(), ScenarioContext.Current.StepContext.StepInfo.Text, "Hotel details are not displayed and cannot book the Hotel");
        }

    }
}
