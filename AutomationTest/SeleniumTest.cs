using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Globalization;
using System.Threading;

namespace AutomationTest
{
    [TestClass]
    public class SeleniumTest
    {
        IWebDriver driver;
        [TestInitialize]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver("./", options);
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }
        [TestMethod]
        public void LoginCorrect()
        {
            LoginPage login = new LoginPage(driver, "admin", "admin");
            login.Login();
            Thread.Sleep(3000);
            var welcome = driver.FindElement(By.Id("nameofuser")).Text;
            driver.Quit();

            Assert.AreEqual(welcome, "Welcome admin");
        }
        [TestMethod]
        public void LoginIncorrect()
        {
            LoginPage login = new LoginPage(driver,"t", "t");
            login.Login();
            Thread.Sleep(3000);
            var error = driver.SwitchTo().Alert().Text;
            driver.Quit();

            Assert.AreEqual(error, "Wrong password.");
        }
        public void addItem()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName("hrefch")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//a[@onclick='addToCart(1)']")).Click();
            Thread.Sleep(3000);
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("cartur")).Click();
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void AddToCartFirstItem()
        {
            addItem();
            var totalPrice = driver.FindElement(By.Id("totalp")).Text;
            driver.Quit();
            Assert.IsTrue(int.Parse(totalPrice)> 0);
        }
        [TestMethod]
        public void RemoveFromCart()
        {
            addItem();
            driver.FindElement(By.XPath("/html/body/div[6]/div/div[1]/div/table/tbody/tr/td[4]/a")).Click();
            Thread.Sleep(3000);
            var totalPrice = driver.FindElement(By.Id("totalp")).Text;
            
            driver.Quit();
            Assert.IsTrue(totalPrice == "");
        }
    }
}
