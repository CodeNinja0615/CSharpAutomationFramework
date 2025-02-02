using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using CSharpSeleniumFramework.utilities;

namespace CSharpSeleniumFramework.pageObjects
{
    public class ProductsPage: CommonFunctions
    {
        private IWebDriver driver;
        public ProductsPage(IWebDriver driver): base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;

        private By checkOut = By.PartialLinkText("Checkout");
        private By cardTitle = By.CssSelector(".card-title a");
        private By addToCart = By.CssSelector(".card-footer button");
        public void WaitForPageToDisplay()
        {
            WaitForElementToAppear(checkOut);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(checkOut));

        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }
        public By getCardTitle()
        {
            return cardTitle;
        }
        public By getAddToCart()
        {
            return addToCart;
        }
        public CheckoutPage checkout()
        {
            checkoutButton.Click();
            return new CheckoutPage(driver);
        }
    }
}
