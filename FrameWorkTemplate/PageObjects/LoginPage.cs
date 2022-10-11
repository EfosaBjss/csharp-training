
using FrameWorkTemplate.UtilityHelpers;
using FrameWorkTemplate.Variable;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkTemplate.PageObjects

  
{
    public class LoginPage
    {
        IWebDriver driver;
        ConfigSetting config;

        public IWebElement UserNameTextField => driver.FindElement(By.Id("username"));
        public IWebElement PasswordTextField =>driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login"));
        string Actualtitle = "Adactin.com - Search Hotel";
      


        public LoginPage()
        {
            driver = Hooks1.driver;
            config = Hooks1.config;
        }



        public void LaunchUrl()
        {
            //driver.Navigate().GoToUrl(ConfigManager.WebSiteUrl);
          // driver.Navigate().GoToUrl("https://adactinhotelapp.com/");
            driver.Navigate().GoToUrl(config.WebSiteUrl);
        }
        
        public void EnterUserNameAndPassword()
        {
            //UserNameTextField.SendKeys(userName);
            //PasswordTextField.SendKeys(password);

            UserNameTextField.SendKeys(config.UserName);
            PasswordTextField.SendKeys(config.Password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ValidateSearchPage()
        {
            string ExpectedTittle = driver.Title;
            Assert.AreEqual(ExpectedTittle, Actualtitle);
            Console.WriteLine("The title of the page is :", ExpectedTittle);
        }
    }
}
