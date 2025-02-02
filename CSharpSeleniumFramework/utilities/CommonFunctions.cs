using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.utilities
{
    public class CommonFunctions
    {
        private IWebDriver driver;
        public CommonFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForElementToAppear(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

        }
    }
}
