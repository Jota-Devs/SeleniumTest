using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Threading;

namespace AutomationTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var driver = new ChromeDriver("./");
        //    Thread.Sleep(2000);
        //    driver.Navigate().GoToUrl("https://www.google.com");
        //    Thread.Sleep(2000);
        //    var element = driver.FindElementByClassName("gLFyf");
        //    element.SendKeys("Hola Mundo");
        //    Thread.Sleep(3000);
        //    driver.FindElementByClassName("gNO89b").Click();
        //    Thread.Sleep(3000);
        //    driver.FindElementByCssSelector("h3").Click();
        //    var titulo = driver.FindElementById("firstHeading").Text;
        //    Thread.Sleep(2000);
        //    driver.Quit();

        //    Assert.AreEqual(titulo, "Hola mundo");
        //}

        [TestMethod]
        public void TestMethod2()
        {
            var driver = new ChromeDriver("./");
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(2000);
            var element = driver.FindElementByClassName("gLFyf");
            element.SendKeys("forms w3schools");
            Thread.Sleep(3000);
            driver.FindElementByClassName("gNO89b").Click();
            Thread.Sleep(3000);
            driver.FindElementByCssSelector("h3").Click();
            var fname = driver.FindElementById("fname");
            fname.Clear();
            fname.SendKeys("Juan");
            var lname = driver.FindElementById("lname");
            lname.Clear();
            lname.SendKeys("Diego");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            var consulta = driver.Url;
            var ret = driver.FindElementByCssSelector("div").Text;
            Thread.Sleep(3000);

            driver.Quit();

            Assert.AreEqual(ret, "fname=Juan&lname=Diego ");
        }
    }
}
