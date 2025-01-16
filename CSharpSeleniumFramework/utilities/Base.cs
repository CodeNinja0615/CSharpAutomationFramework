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
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;

namespace CSharpSeleniumFramework.utilities
{
    public class Base
    {
        String browserName;
        public ExtentReports extent;
        public ExtentTest test;
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmpRporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmpRporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "Sameer Akhtar");
        }
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new();// ThreadLocal<IWebDriver>();

        [SetUp]
        public void StartBrowser()
        {
            test =extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("hh_mm_ss") + ".png";
            if(status == TestStatus.Failed)
            {
                test.Fail("Test Failed", CaptureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, $"Test failed with logtrace {stacktrace}");
            }
            else if(status == TestStatus.Passed)
            {

            }
            driver.Value.Quit();
            //driver.Value.Dispose();
        }
        [OneTimeTearDown]
        public void tearDown(){
            extent.Flush();
        }
        public Media CaptureScreenShot(IWebDriver driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            Media media = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
            return media;
        }
    }
}

// dotnet test CSharpSeleniumFramework.csproj --filter TestCategory=Regression --% -- TestRunParameters.Parameter(name=\"browserName\",value=\"Edge\")