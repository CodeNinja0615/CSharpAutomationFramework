using NUnit.Framework.Legacy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using CSharpSeleniumFramework.utilities;
using CSharpSeleniumFramework.pageObjects;

namespace CSharpSeleniumFramework.tests
{
    public class Tests : Base
    {
        [Test]
        public void EndToEndFlow()
        {

            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productPage = loginPage.ValidLogin(userid: "rahulshettyacademy", pass: "learning");
            productPage.WaitForPageToDisplay();
            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.getAddToCart()).Click();
                }
            }

            CheckoutPage checkoutPage = productPage.checkout();
            IList<IWebElement> checkoutCards = checkoutPage.CheckoutCards();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;



            }
            Assert.That(expectedProducts, Is.EqualTo(actualProducts));

            CountryPage countryPage = checkoutPage.Checkout();
            countryPage.SelectCountry();


            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirText);

        }
    }
}
