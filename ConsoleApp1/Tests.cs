using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FMIExamples
{
    class FMIExamples
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void test()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.mail.bg/");
            driver.Manage().Window.Maximize();
            
            IWebElement username = driver.FidElement(By.Id("username")); 
            IWebElement password = driver.FindElement(By.Id("password"));
            IWebElement loginBtn = driver.FindElement(By.Id("loginBut"));
            IWebElement lostPasswordLink = driver.FindElement(By.Id("lostPasswordLink"));
            
            Assert.AreEqual(lostPasswordLink.Text, "Забравена парола");
            

            username.Click();

            username.SendKeys("testing_fmi");

            password.Click();
            password.SendKeys("123456fmi");

            loginBtn.Click();

            IWebElement usernameLabel = driver.FindElement(By.Id("gwt-uid-406"));
            Assert.AreEqual(usernameLabel.Text, "testing_fmi@abv.bg");

            driver.Quit();
            // Comment
        }
    }
}