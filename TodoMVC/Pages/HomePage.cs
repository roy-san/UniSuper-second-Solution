using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TodoMVC.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        
        public HomePage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='examples/angularjs']")]
        public IWebElement AngularLink { get; set; }
       
        public void ClickOnAngularLink()
        {
            AngularLink.Click();
        }

    }
}
