using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ShopDemo.Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation.Fragments
{
    public class GlobalMenuFragment:BaseFragment
    {
        public GlobalMenuFragment(IAppDriver driver):base(driver)
        {            
        }
        public bool HasMainMenu()
        {
            return FindById("menu-main-menu").Displayed;
        }

        public void MoveToMainMenu(string menuTitle)
        {
            IWebElement link = FindByLinkText(menuTitle);
            IWebElement parent = link.FindElement(By.XPath(".."));
            Actions action = new Actions(Driver);
            action.MoveToElement(parent).Perform();
        }

        public void ClickMainMenu(string menuTitle)
        {
            IWebElement link = FindByLinkText(menuTitle);
            IWebElement parent = link.FindElement(By.XPath(".."));
            parent.Click();
        }

        public void ClickSubMenu(string menuTitle,string subMenuTitle)
        {
            IWebElement link = FindByLinkText(menuTitle);
            IWebElement parent = link.FindElement(By.XPath(".."));
            IWebElement child = parent.FindElement(By.LinkText(subMenuTitle));
            child.Click();
        }

        public int GetCartCount()
        {
            IWebElement count = FindByClassName("cart-count");
            return Convert.ToInt32(count.Text??"0");
        }

        public string GetPageTitle()
        {
            string pageTitle = Driver.Title;
            return pageTitle;
        }
    }
}
