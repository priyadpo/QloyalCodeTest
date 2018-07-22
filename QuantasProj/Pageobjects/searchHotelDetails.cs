using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QuantasProj.Extensions;
using TechTalk.SpecFlow;
using System.Collections;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.Threading;

namespace QuantasProj.Pageobjects
{
    public class searchHotelDetails:PageObjectBase
    {

        [FindsBy(How = How.CssSelector, Using = "section.grey-box > div > div > div:nth-child(1) > div > div > div.col-md-9 > div.col-md-12 > div > div:nth-child(1) > div > a")]
        private IWebElement btnPHPTravelSite;

        [FindsBy(How = How.CssSelector, Using = "div[id=body-section] > section > div.cell > div.container")]
        private IWebElement elmPromoContainer;

       [FindsBy(How = How.CssSelector, Using = "#s2id_autogen2")]
        private IWebElement elmHotelName;

        [FindsBy(How = How.CssSelector, Using = "body:nth-child(2)>nav:nth-child(4)>div>div>ul:nth-child(1)>li:nth-child(2)>a")]
        private IWebElement elmHotelMenu;

        [FindsBy(How = How.CssSelector, Using = "div[id=select2-drop]>ul>li")]
        private IList<IWebElement> elmHotelList;

        [FindsBy(How = How.CssSelector, Using = "#dpd1>div>input")]
        private IWebElement elmStartDate;

        [FindsBy(How = How.CssSelector, Using = "#dpd2>div>input")]
        private IWebElement elmEndDate;

        [FindsBy(How = How.CssSelector, Using = "div.search_head:nth-child(3)>div>form:nth-child(2)>div:nth-child(5) > button:nth-child(3)")]
        private IWebElement btnSubmit;

        [FindsBy(How = How.CssSelector, Using = "#ROOMS > div> div:nth-child(1)")]
        private IWebElement elmHotelDetailsPanel;

        [FindsBy(How = How.CssSelector, Using = "#ROOMS >div>table > tbody > tr:nth-child(1) > td>div:nth-child(2)>div:nth-child(2)>div>div:nth-child(3)>div> button")]
        private IWebElement bthBookHotel;
        public searchHotelDetails() : base()
        {
        }
        public bool NavigateToPHPTravelsSite()
        {
            try
            {
                var phpTravelUrl = Utilities.GetAppSettings("url");
                ScenarioContext.Current.Add("URL", phpTravelUrl);   
                driver.Navigate().GoToUrl(phpTravelUrl);
                driver.FindElement(By.TagName("body")).SendKeys(Keys.Tab);                
                return true;               
                // btnPHPTravelSite.WaitAndClick();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool AddHotelDetails(string hotelName, string startDate,string endDate,int adultCount,int childCount)
        {
            try
            {

                if (elmHotelMenu.Displayed && elmHotelMenu.Enabled)
                {

                    elmHotelMenu.WaitAndClick();

                    driver.FindElement(By.TagName("body")).SendKeys(Keys.Tab);
                    elmHotelName.SendKeys(Keys.Shift);
                    if (elmHotelName.Displayed && elmHotelName.Enabled)
                    {
                        elmHotelName.WaitAndSendKeys(hotelName);
                       Thread.Sleep(1000);
                        var el_count = elmHotelList.Count();
                        if (el_count != 0)
                        {
                            for (int index = 0; index < el_count; index++)
                            {
                              
                                if (elmHotelList[index].FindElement(By.CssSelector("li:nth-child(1)>ul>li:nth-child(1)>div")).Enabled)
                                {
                                    elmHotelList[index].FindElement(By.CssSelector("li:nth-child(1)>ul>li:nth-child(1)>div")).WaitAndClick();
                                    AddStartDate(startDate);
                                    AddEndDate(endDate);
                                    return true;
                                }

                            }
                        }
                    }
                }
               return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool AddStartDate(string startDate)
        {
            try
            {
                    elmStartDate.SendKeys(Keys.Shift);
                    if (elmStartDate.Displayed && elmStartDate.Enabled)
                    {
                        elmStartDate.WaitAndSendKeys(startDate);
                        return true;
                    }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool AddEndDate(string endDate)
        {
            try
            {
                elmEndDate.SendKeys(Keys.Shift);
                if (elmEndDate.Displayed && elmEndDate.Enabled)
                {
                    elmEndDate.WaitAndSendKeys(endDate);
                        return true;               
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool clickSearch()
        {
            try
            {
                if (btnSubmit.Displayed && btnSubmit.Enabled)
                {
                    btnSubmit.WaitAndClick();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool HotelDetailsPanelDisplayed()
        {
            try
            {
                if (elmHotelDetailsPanel.Displayed && elmHotelDetailsPanel.Enabled)
                {
                    bthBookHotel.SendKeys(Keys.Shift);
                    if (bthBookHotel.Displayed && bthBookHotel.Enabled)
                    {
                        bthBookHotel.WaitAndClick();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
    
}
