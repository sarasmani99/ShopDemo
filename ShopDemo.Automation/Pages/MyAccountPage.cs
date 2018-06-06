using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation.Pages
{
    public class MyAccountPage: Basepage
    {
        public MyAccountPage(IAppDriver driver) : base(driver)
        { }
        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Driver.AppUrl);
        }

        public void EnterUserNameOrEmailAddressToLogIn(string emailAddress)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
            FindById("username").Clear();
            FindById("username").SendKeys(emailAddress);
        }

        public void EnterPasswordToLogIn(string pwd)
        {
            FindById("password").Clear();
            FindById("password").SendKeys(pwd);
        }

        public void ClickLogIn()
        {
            FindByName("login").Click();
        }

        public bool SummaryHasErrorMessage(string message)
        {
            bool isContains=false;
            var errorMessageParent = FindByClassName("woocommerce-error");
            var errorElement = errorMessageParent.FindElement(By.TagName("li")).Text;
            if (errorElement.Contains(message))
                return isContains = true;
            else
                return isContains = false;
        }
        
        public bool IsSuccessfullyLoggedIn()
        {
            var parentEle=FindByClassName("woocommerce-MyAccount-content");
            var pgElement = parentEle.FindElement(By.TagName("p"));
            var element = pgElement.FindElement(By.TagName("a"));
            if (element.Text=="Sign out")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EnterEmailAdressToRegister()
        {

        }

        public void EnterPasswordToRegister()
        {

        }


    }
}
