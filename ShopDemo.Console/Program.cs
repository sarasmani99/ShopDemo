using ShopDemo.Automation;
using ShopDemo.Automation.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopDemo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IAppDriver driver = new AppChromeDriver();
            //driver.AppUrl= "http://shop.demoqa.com";

            // ShopDemoMainPage sdp = new ShopDemoMainPage(driver);
            //// sdp.Navigate();
            //// sdp.categoryEnum = ShopDemoMainPage.Menu.WOMAN;
            // ItemsPage itemsPage = new ItemsPage(driver);
            MyAccountPage map = new MyAccountPage(driver);
            driver.AppUrl=("http://shop.demoqa.com/my-account/");
            map.Navigate();
            map.EnterUserNameOrEmailAddressToLogIn("m_sarsu@outlook.com");
            map.EnterPasswordToLogIn("GreatToStay@5624");
            map.ClickLogIn();
            map.IsSuccessfullyLoggedIn();



            //int itemCount = sdp.GlobalMenu.GetCartCount();
            //sdp.GlobalMenu.ClickMainMenu("WOMAN");
            ////itemsPage.FilterByColor("Black");
            //itemsPage.cartOptions = ItemsPage.AfterAddAction.ContinueShopping;
            //Thread.Sleep(10000);
            //itemsPage.FilterByColor("Brown");

            //List<string> nameList=itemsPage.GetAllItemNames();
            //nameList.Add("ALEXA FAUX LEATHER SADDLE BAG");
            // nameList.Add("COACHELLA EMBROIDERED MAXI DRESS");
            // Random rnd = new Random();
            // int i = rnd.Next(nameList.Count);

            //itemsPage.AddItemsToCart("CLEAN PU CARINA CLUTCH", itemsPage.cartOptions);
            //itemsPage.AddItemsToCart("ALEXA FAUX LEATHER SADDLE BAG", itemsPage.cartOptions);
            //itemsPage.AddItemsToCart("FLORAL CAGE MIDI DRESS", itemsPage.cartOptions);
            //itemsPage.AddItemsToCart("COTSWOLDS COATING OVERSIZED COAT", itemsPage.cartOptions);
            //itemsPage.AddItemsToCart("HETTIE JEWELS MAXI DRESS", itemsPage.cartOptions);
            //i = rnd.Next(nameList.Count);

            //itemsPage.cartOptions = ItemsPage.AfterAddAction.ViewCart;
            //itemsPage.AddItemsToCart((string)nameList[i], itemsPage.cartOptions);
            //int itemCountAfterAdd = sdp.GlobalMenu.GetCartCount();

            driver.Quit();
           // ReadExcelFile("LogInData", "D:\\sarsu\\ShoppingData.xlsx");
            
            

        }

        private static DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'";
               // conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Persist Security Info=False";
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = "select * from [" + sheetName + "$]";
                    cmd.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        return dt;
                    }
                }

            }

        }
    }
}
