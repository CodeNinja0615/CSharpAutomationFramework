using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");

        //--Page object Factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkBox;

        [FindsBy(How = How.XPath, Using = "//input[@value='Sign In']")]
        private IWebElement signIn;

        /// <summary>
        /// this makes username publically accessible
        /// </summary>
        /// <returns></returns>
        public IWebElement getUserName()
        {
            return username;
        } 
        public ProductsPage ValidLogin(String userid, String pass)
        {
            username.SendKeys(userid);
            password.SendKeys(pass);
            checkBox.Click();
            signIn.Click();
            return new ProductsPage(driver);
        }
    }
}
