using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CSharpSeleniumFramework.testData;

namespace CSharpSeleniumFramework.utilities
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            if (browserName == null)
            {
                InitBrowser("Edge");
            }
            else
            {
                InitBrowser(browserName);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }
        public void InitBrowser(string browserName) 
        {
            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;
            }
        }

        public static JSONReader GetDataParser()
        {
            return new JSONReader();
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
