using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
    public class CountryPage
    {
        private IWebDriver driver;
        public CountryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;
        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement countryLink;

        private By India = By.LinkText("India");
        public void SelectCountry()
        {
            country.SendKeys("ind");
            new CommonFunctions(driver).WaitForElementToAppear(India);
            countryLink.Click();
        }
    }
}
