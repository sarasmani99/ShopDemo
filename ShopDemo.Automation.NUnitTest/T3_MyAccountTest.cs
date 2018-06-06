using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using ShopDemo.Automation.NUnitTest.PageFactory;
using ShopDemo.Automation.NUnitTest.TestData;
using ShopDemo.Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopDemo.Automation.NUnitTest
{
    [TestFixture]
    public class T3_MyAccountTest
    {
        private static IAppDriver driver = null;
        MyAccountPage mcp = null;

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Provider.CreateDriver();
            mcp = new MyAccountPage(driver);
            driver.AppUrl=("http://shop.demoqa.com/my-account/");
            mcp.Navigate();
        }

        [Test]
        [TestCaseSource(typeof(LoginData),"GetData")]
        public void PerformLogIn(LoginData data)
        {
            //driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
            mcp.EnterUserNameOrEmailAddressToLogIn(data.UserNameOrEmailAddress);
            
            mcp.EnterPasswordToLogIn(data.Password);
            mcp.ClickLogIn();
            if (data.ExpectedResult == "Pass")
            {
                Assert.IsTrue(mcp.IsSuccessfullyLoggedIn(),"LogIn is not successful");
            }
            else if (data.ExpectedResult  == "Fail")
            {
                Assert.IsTrue(mcp.SummaryHasErrorMessage(data.ExpectedError), "Validation verification is not successful");
            }
            else
            {
                throw new Exception("Unknown expected result, fix data file");
            }
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Quit();
        }


    }
}
