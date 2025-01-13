using NUnit.Framework.Legacy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using CSharpSeleniumFramework.utilities;
using CSharpSeleniumFramework.pageObjects;
using CSharpSeleniumFramework.testData;

namespace CSharpSeleniumFramework.tests
{
    [Parallelizable(ParallelScope.Children)] //---Parallel execution of all method in a class & use .Self to run this class in parallel with mutliple class
    public class Tests : Base
    {
        [Test, TestCaseSource(nameof(AddTestDataConfig))]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[Parallelizable(ParallelScope.All)] //---All data sets parallel execution
        public void EndToEndFlow(String userName, String password, String[] expectedProducts)
        {
            string[] actualProducts = new string[2];
            //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            LoginPage loginPage = new LoginPage(getDriver());

            ProductsPage productPage = loginPage.ValidLogin(userName, password);
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

            ConfirmationPage confirmationPage = checkoutPage.Checkout();
            confirmationPage.SelectCountry();
            string confirmText = confirmationPage.ConfirmPurchase();
            //StringAssert.Contains("Success", confirmText);
            Assert.That(confirmText.Contains("Success"));

        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test 2");
        }
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(GetDataParser().ExtractData("username"), GetDataParser().ExtractData("password"), GetDataParser().ExtractDataArray("products"));
            yield return new TestCaseData(GetDataParser().ExtractData("username_wrong"), GetDataParser().ExtractData("password_wrong"), GetDataParser().ExtractDataArray("products"));
            yield return new TestCaseData(GetDataParser().ExtractData("username"), GetDataParser().ExtractData("password"), GetDataParser().ExtractDataArray("products"));
        }


        /// <summary>
        /// To pull data fron json when structured as list of hashmaps
        /// </summary>
        /// <returns></returns>
        //public static IEnumerable<TestCaseData> GetData()
        //{
        //    var data = JSONReader.GetJsonDataToDictionary();

        //    yield return new TestCaseData(data[0]);
        //    yield return new TestCaseData(data[1]);
        //}
    }
}
