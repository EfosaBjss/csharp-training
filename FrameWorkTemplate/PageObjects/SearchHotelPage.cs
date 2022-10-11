using FrameWorkTemplate.UtilityHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkTemplate.PageObjects
{
   
    public class SearchHotelPage:Hooks1
    {
        Waits waits = new Waits();

        public IWebElement Location => driver.FindElement(By.Id("location"));
        public IWebElement Hotels => driver.FindElement(By.Id("hotels"));
        public IWebElement RoomType => driver.FindElement(By.Id("room_type"));
        public IWebElement NumberOfRooms => driver.FindElement(By.Id("room_nos"));
        public IWebElement CheckInDate => driver.FindElement(By.Id("datepick_in"));
        public IWebElement CheckOutDate => driver.FindElement(By.Id("datepick_out"));
        public IWebElement AdultsPerRoom => driver.FindElement(By.Id("adult_room"));
        public IWebElement ChildrenPerRoom => driver.FindElement(By.Id("child_room"));
        public IWebElement Search => driver.FindElement(By.Id("Submit"));
        public IWebElement BookedItinary => driver.FindElement(By.LinkText("Booked Itinerary"));

   

        public void ValidateSearchHotelPage()
            
        {
            string ActualTile = "Adactin.com - Search Hotel";
            string ExpectedTitle = driver.Title;
            Assert.AreEqual(ExpectedTitle, ActualTile);
        }

        public void EnterSearchCriterias(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var test = dictionary["Location"];

            waits.WaitForElement(driver, Location);
            SelectElement selectLocation = new SelectElement(Location);
            selectLocation.SelectByText(dictionary["Location"]);
            
            SelectElement selectHotel = new SelectElement(Hotels);
            selectHotel.SelectByText(dictionary["Hotels"]);

            SelectElement selectRoomType = new SelectElement(RoomType);
            selectRoomType.SelectByText(dictionary["RoomType"]);

            SelectElement selectRoomNos = new SelectElement(NumberOfRooms);
            selectRoomNos.SelectByText(dictionary["NumberOfRooms"]);

            CheckInDate.SendKeys(dictionary["CheckInDate"]);
            CheckOutDate.SendKeys(dictionary["CheckOutDate"]);

            SelectElement selectAdultsPerRoom = new SelectElement(AdultsPerRoom);
            selectAdultsPerRoom.SelectByText(dictionary["AdultsPerRoom"]);

            SelectElement selectChildrenPerRoom = new SelectElement(ChildrenPerRoom);
            selectChildrenPerRoom.SelectByText(dictionary["ChildrenPerRoom"]);
        }
        

        public void ClickSearchButton()
        {
            waits.WaitForElement(driver, Search);
            Search.Click();
        } 

       
        public void ValidateItinaryPage()
        {
            if (BookedItinary.Displayed)
            {
                Console.WriteLine("Test is passed");
            }
            else
            { Console.WriteLine("Test is failed"); }
        }
        

    }
}
