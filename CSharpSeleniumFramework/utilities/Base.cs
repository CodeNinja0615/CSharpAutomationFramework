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
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new();// ThreadLocal<IWebDriver>();

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
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }
        public void InitBrowser(string browserName) 
        {
            switch (browserName)
            {
                case "Firefox":
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    driver.Value = new EdgeDriver();
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
            driver.Value.Dispose();
        }
    }
}
