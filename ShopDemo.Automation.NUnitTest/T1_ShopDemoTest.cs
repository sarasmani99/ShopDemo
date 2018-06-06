//using NUnit.Framework;
//using ShopDemo.Automation.Pages;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ShopDemo.Automation.NUnitTest.PageFactory;
//using System.Threading;

//namespace ShopDemo.Automation.NUnitTest
//{
//    [TestFixture]
//    public class T1_ShopDemoPageTest
//    {
//        private static IAppDriver driver = null;
//        ShopDemoMainPage sdp = null;
//        [OneTimeSetUp]
//        public void Initialize()
//        {
//            //Thread.Sleep(100000);
//            driver = Provider.CreateDriver();
//            sdp = new ShopDemoMainPage(driver);
//            driver.AppUrl = "http://shop.demoqa.com";
//            sdp.Navigate();
//        }

//        [Test]
//        public void T1_01_IsShoppingDemoSiteOpenedSuccessfully()
//        {
//            Assert.IsTrue(sdp.IsPageOpenedSuccessfully());
//        }

//        [Test]
//        public void T1_02_GoToWomanCategory()
//        {
//            Thread.Sleep(10000);
//            sdp.GlobalMenu.ClickMainMenu("WOMAN");
//            string pageTitle = sdp.GlobalMenu.GetPageTitle();
//            Assert.IsTrue(pageTitle.Equals("Women – Demo Shopping site"));
//        }

//        [Test]
//        public void T1_03_GoToManCategory()
//        {
//            sdp.categoryEnum = ShopDemoMainPage.Menu.MAN;
//            sdp.GlobalMenu.ClickMainMenu("MAN");
//            string pageTitle = sdp.GlobalMenu.GetPageTitle();
//            Assert.IsTrue(pageTitle.Equals("Men – Demo Shopping site"), "Man Category should open");
//        }

//        [Test]
//        public void T1_04_GoToHome()
//        {
//            sdp.categoryEnum = ShopDemoMainPage.Menu.HOME;
//            ItemsPage itemsPage = sdp.GoToCategory(sdp.categoryEnum);
//            if (itemsPage != null)
//                Assert.IsTrue(true);
//        }

//        [Test]
//        public void T1_05_GoToMyAccount()
//        {
//            sdp.GlobalMenu.ClickMainMenu("MY ACCOUNT");
//            string pageTitle = sdp.GlobalMenu.GetPageTitle();
//            Assert.IsTrue(pageTitle.Equals("My Account – Demo Shopping site"));
//        }

//        [Test]
//        public void T1_06_GoToSale()
//        {
//            sdp.GlobalMenu.ClickMainMenu("SALE");
//            string pageTitle = sdp.GlobalMenu.GetPageTitle();
//            Assert.IsTrue(pageTitle.Equals("Sale – Demo Shopping site"));
//        }

//        [OneTimeTearDown]
//        public void EndTest()
//        {
//            driver.Quit();
//        }
//    }
//}
