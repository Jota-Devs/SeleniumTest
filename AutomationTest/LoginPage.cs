using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AutomationTest
{
    public class LoginPage
    {
        private IWebDriver driver;
        private string user;
        private string pass;
        public LoginPage(IWebDriver Driver, string User, string Pass)
        {
            driver = Driver;
            user = User;
            pass = Pass;
        }
        public void Login()
        {
            driver.FindElement(By.Id("login2")).Click();
            Thread.Sleep(2000);
            var user = driver.FindElement(By.Id(("loginusername")));
            user.SendKeys(this.user);
            Thread.Sleep(2000);
            var pass = driver.FindElement(By.Id(("loginpassword")));
            pass.Clear();
            pass.SendKeys(this.pass);
            Thread.Sleep(2000);
            var btn = driver.FindElement(By.XPath("//button[contains(text(),'Log in')]"));
            btn.Click();
        }
    }
}
