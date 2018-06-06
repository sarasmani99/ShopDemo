using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation.Pages
{
    public class ShopDemoMainPage:Basepage
    {
        public ShopDemoMainPage(IAppDriver driver) : base(driver)
        {

        }
        public enum Menu
        {
            WOMAN,
            MAN=1,
            HOME=2,
            MYACCOUNT=3,
            SALE=4
        };

        public Menu categoryEnum { get; set; }
        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Driver.AppUrl);
        }


        public bool IsPageOpenedSuccessfully()
        {
            var menu=FindById("menu-main-menu");
            if (menu.FindElement(By.LinkText("WOMAN")).Displayed)
                return true;
            else
                return false;
        }

        public ItemsPage GoToCategory(Menu category)
        {
            var menu = FindById("menu-main-menu");
            ItemsPage itemsPage = null;
            bool isClickSuccessfull = false;
            switch (category)
            {
                case  Menu.WOMAN:
                    menu.FindElement(By.LinkText("WOMAN")).Click();
                    isClickSuccessfull = true;
                    break;
                case Menu.MAN:
                    menu.FindElement(By.LinkText("MAN")).Click();
                    isClickSuccessfull = true;
                    break;
                case Menu.HOME:
                    menu.FindElement(By.LinkText("HOME")).Click();
                    isClickSuccessfull = true;
                    break;
                case Menu.MYACCOUNT:
                    menu.FindElement(By.LinkText("MY ACCOUNT")).Click();
                    isClickSuccessfull = true;
                    break;
                case Menu.SALE:
                    menu.FindElement(By.LinkText("SALE")).Click();
                    isClickSuccessfull = true;
                    break;
            }
            if (isClickSuccessfull)
                itemsPage = new ItemsPage(Driver);

            return itemsPage;

        }
    }
}
