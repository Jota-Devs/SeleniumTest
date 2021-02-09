using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;


namespace AutomationTest
{
    [TestClass]
    public class AutomationWispero
    {
        IWebDriver driver;
        [TestInitialize]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver("./", options);
            driver.Navigate().GoToUrl("https://localhost:44352/");
        }

        [DynamicData(nameof(ReadExcel), DynamicDataSourceType.Method)]
        [TestMethod]
        public void AddQuestionAndAnwserWithExcell(string Question, string Answer, string Tags)
        {
            driver.FindElement(By.Id("Question")).SendKeys(Question);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Answer")).SendKeys(Answer);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Tags")).SendKeys(Tags);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(text(),'Submit')]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='TagCloud']/div[1]/h2/a")).Click();
            Thread.Sleep(1000);

            driver.Quit();
        }
        //EPPlus
        public static IEnumerable <object[]> ReadExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo("C:/Users/Juandi/source/repos/ConsoleApp2/AutomationTest/data.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Hoja1"];
                for (int row = 2; row <= 7; row++)
                {
                    yield return new object[] {
                        worksheet.Cells[row, 1].Value?.ToString().Trim(), // Question
                        worksheet.Cells[row, 2].Value?.ToString().Trim(), // Awnser
                        worksheet.Cells[row, 3].Value?.ToString().Trim()  // Tags
                    };
                }
            }
        }


      
    }
}
