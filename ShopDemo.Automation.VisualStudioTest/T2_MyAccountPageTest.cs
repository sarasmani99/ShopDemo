using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDemo.Automation.Pages;
using ShopDemo.Automation.VisualStudioTest.PageFactory;
using ShopDemo.Automation.VisualStudioTest.TestData;

namespace ShopDemo.Automation.VisualStudioTest
{
    [TestClass]
    public class T2_MyAccountPageTest
    {
        const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =D:\\sarsu\\SeleniumProjects\\ShopDemo.Test\\ShopDemo.Automation.NUnitTest\\Data\\ShoppingData.xlsx; Extended Properties = 'Excel 12.0;HDR=yes';";

        public static MyAccountPage map = null;
        private static IAppDriver driver = null;

        public TestContext TestContext { get; set; }
        [ClassInitialize]
        public void Initialize(TestContext c)
        {
            driver = Provider.CreateDriver();
            map = new MyAccountPage(driver);
            driver.AppUrl = "http://shop.demoqa.com/my-account/";
            map.Navigate();
        }

        [TestMethod]
        [DataSource("System.Data.OleDB", ConnectionString, "LogInData$", DataAccessMethod.Sequential)]
        public void Perform_LogIn()
        {
            Thread.Sleep(5000);
            LoginData ld = new LoginData(TestContext.DataRow);
            map.EnterUserNameOrEmailAddressToLogIn(ld.UserNameOrEmailAddress);
            map.EnterPasswordToLogIn(ld.Password);
            map.ClickLogIn();
            Thread.Sleep(5000);
            if (ld.ExpectedResult == "Pass")
            {
                Assert.IsTrue(map.IsSuccessfullyLoggedIn(), "LogIn is not successful");
            }
            else if (ld.ExpectedResult == "Fail")
            {
                Assert.IsTrue(map.SummaryHasErrorMessage(ld.ExpectedError), "Validation verification is not successful");
            }
            else
            {
                throw new Exception("Unknown expected result, fix data file");
            }
        }

        [ClassCleanup]
        public static void Dispose()
        {
            driver.Quit();
        }
    }
}
