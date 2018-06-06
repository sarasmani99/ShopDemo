//using NUnit.Framework;
//using ShopDemo.Automation.Pages;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ShopDemo.Automation.NUnitTest.PageFactory;
//using System.Threading;
//using OfficeOpenXml;
//using ShopDemo.Automation.NUnitTest.TestData;
//using EPPlus.DataExtractor;

//namespace ShopDemo.Automation.NUnitTest
//{
//    [TestFixture]
//    public class T2_ItemsPageTest
//    {
//        private static IAppDriver driver = null;
//        ItemsPage itemsPage = null;

//        [OneTimeSetUp]
//        public void Initialize()
//        {
//            driver = Provider.CreateDriver();
//            itemsPage = new ItemsPage(driver);
//            driver.AppUrl = "http://shop.demoqa.com/product-tag/women/";
//            itemsPage.Navigate();
//        }

//        private void AddItemsToCart(ItemsPage.AfterAddAction action)
//        {
//            Random rnd = new Random();
//            int itemCountBeforeAdd = sdp.GlobalMenu.GetCartCount();
//            //itemsPage.FilterByColor("Brown");
//            var nameList = itemsPage.GetAllItemNames();
//            var addedItems = new List<string>();

//            int itemsTobeAdded = rnd.Next(1, nameList.Count);
//            while (itemsTobeAdded > 0)
//            {
//                var itemName = nameList[rnd.Next(0, nameList.Count - 1)];
//                if (!addedItems.Contains(itemName))
//                {
//                    if (action == ItemsPage.AfterAddAction.ViewCart)
//                    {
//                        if (itemsTobeAdded == 1)
//                        {
//                            itemsPage.AddItemsToCart(itemName, ItemsPage.AfterAddAction.ViewCart);
//                        }
//                        else
//                        {
//                            itemsPage.AddItemsToCart(itemName, ItemsPage.AfterAddAction.ContinueShopping);
//                        }
                        
//                    }
//                    else
//                    {
//                        itemsPage.AddItemsToCart(itemName, action);
//                    }
//                    addedItems.Add(itemName);
//                    itemsTobeAdded--;
//                }
//            }
//            Thread.Sleep(5000);
//            if (action != ItemsPage.AfterAddAction.ViewCart)
//            {
//                Assert.AreEqual(itemCountBeforeAdd + addedItems.Count, sdp.GlobalMenu.GetCartCount(), "Added items not in cart");
//            }
//        }

//        [Test]
//        public void T2_01_AddItemsToCartThenContinueShopping()
//        {
//            Thread.Sleep(10000);
//            AddItemsToCart(ItemsPage.AfterAddAction.ContinueShopping);    
//        }


//        [Test]
//        public void T2_02_AddItemsToCartThenGoToViewCart()
//        {
//            Thread.Sleep(5000);
//            itemsPage.Navigate();
//            AddItemsToCart(ItemsPage.AfterAddAction.ViewCart);
//            string pageTitle = itemsPage.GlobalMenu.GetPageTitle();
//            Assert.AreEqual(pageTitle.Equals("Cart – Demo Shopping site"), "View cart page not opened");
//        }

//        static IEnumerable<ItemsPageTestData> T7_DataSource()
//        {
//            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo("./Data/ShoppingData.xlsx")))
//            {
//                var sheet = package.Workbook.Worksheets[0];
//                var d = sheet.Extract<ItemsPageTestData>()
//                    .WithProperty(p => p.ItemsToAddCart, "A")
//                    .GetData(2, 4)
//                    .ToList();
//                return d;
//            }
//        }

//        [Test]
//        public void T2_03_FilterByColor()
//        {
//            sdp.Navigate();
//            bool isFilter=itemsPage.FilterByColor("Brown");
//            Assert.IsTrue(isFilter, "Filter with color not working");
//        }

//        [OneTimeTearDown]
//        public void EndTest()
//        {
//            driver.Quit();
//        }
        
//    }
//}
