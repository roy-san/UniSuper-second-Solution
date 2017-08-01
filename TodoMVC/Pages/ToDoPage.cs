using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TodoMVC.Pages
{
    public class ToDoPage
    {
        private IWebDriver driver;
        
        public ToDoPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id, Using = "new-todo")]
        public IWebElement ToDoInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='todo-list']/li")]
        public IList<IWebElement> todoList { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='todo-list']/li[1]/div/input")]
        public IWebElement circleInput1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='todo-list']/li[2]/div/input")]
        public IWebElement circleInput2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Completed']")]
        public IWebElement completeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']//a[text()='All']")]
        public IWebElement allButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='toggle-all']")]
        public IWebElement toggleAll { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='todo-list']/li[1]/div/button")]
        public IWebElement closeButton { get; set; }
                
        public void EnterToDoName(String name)
        {            
            ToDoInput.SendKeys(name);
            ToDoInput.SendKeys(Keys.Enter);
            
            Boolean status = false;
            int count = todoList.Count;
            Assert.IsTrue(count >= 1, "To do list added");

            foreach(IWebElement element in todoList){
                String text = element.Text;
                if (text.Equals(name))
                {
                    status = true;
                    break;
                }
            }
            if (!status)
            {
                   Assert.Fail("To do not added test failed");
            }
        }


        public void selectCompleteCircle(int i)
        {
            switch(i){
                case 1:
                    circleInput1.Click();
                    break;
                case 2:
                    circleInput2.Click();
                    break;
                default:
                    circleInput1.Click();
                    break;
            }
            
        }

        public void clickCompleteFilter()
        {
            completeButton.Click();
        }

        public void verifyToDoComplete(String name)
        {
            IList<IWebElement> todoList1 = driver.FindElements(By.XPath("//ul[@id='todo-list']/li"));
            Boolean status = false;
            foreach (IWebElement element in todoList1)
            {
                String text = element.Text;
                if (text.Equals(name))
                {
                    status = true;
                    break;
                }
            }
            if (!status)
            {
                Assert.Fail("To do not completed");
            }
        }

        public void verifyToDoNotFound(String name)
        {
            IList<IWebElement> todoList1 = driver.FindElements(By.XPath("//ul[@id='todo-list']/li"));
            Boolean status = false;
            foreach (IWebElement element in todoList1)
            {
                String text = element.Text;
                if (text.Equals(name))
                {
                    status = true;
                    break;
                }
            }
            if (status)
            {
                Assert.Fail("To do is under complete filter");
            }
        }

        public void unSelectCircleButton()
        {
            this.selectCompleteCircle(1);
        }

        public void clickAllButton()
        {
            allButton.Click();
        }

        public void clickAllCheckBox()
        {
            toggleAll.Click();
        }

        public void clickCloseButton()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(circleInput1).Build().Perform();
            closeButton.Click();
        }

       
    }
}
