using FrameWorkTemplate.UtilityHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkTemplate.PageObjects
{
    public class BasePage : Hooks1
    {

        public T CurrentPage<T>() where T : BasePage, new ()
        {
            var page = new T {};
            return page;
        }
    public string GetPageTitle()
        {
            return driver.Title;
        }

        public void MoveToElement(IWebElement element)
        {
            Actions a = new Actions(driver);
            a.MoveToElement(element).Perform();
        }

        public void MoveToAndHighlightElementOnPage(IWebElement element)
        {
            //This moves to the element 
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            //This Highlight the element 
            var jsDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: yellow; background : yellow"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }
    
}
}
