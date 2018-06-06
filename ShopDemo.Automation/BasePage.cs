using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ShopDemo.Automation.Fragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation
{
    public class BaseFragment
    {
        protected IAppDriver Driver { get; private set; }


        public BaseFragment(IAppDriver driver)
        {
            Driver = driver;
        }



        public IWebElement FindById(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        public IWebElement FindByName(string name)
        {
            return Driver.FindElement(By.Name(name));
        }

        public IWebElement FindByXpath(string path)
        {
            return Driver.FindElement(By.XPath(path));
        }

        public IWebElement FindByClassName(string className)
        {
            return Driver.FindElement(By.ClassName(className));
        }

        public IWebElement FindByLinkText(string linkText)
        {
            return Driver.FindElement(By.LinkText(linkText));
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor exe = (IJavaScriptExecutor)this.Driver;
            exe.ExecuteScript("arguments[0].scrollIntoView()",element);
        }

        public object ExecuteScript(string script)
        {
            IJavaScriptExecutor exe = (IJavaScriptExecutor)this.Driver;
            return exe.ExecuteScript(script);
        }
    }

    public class Basepage : BaseFragment
    {
        public Basepage(IAppDriver driver) : base(driver)
        {
            GlobalMenu = new GlobalMenuFragment(driver);
        }

        public GlobalMenuFragment GlobalMenu { get; set; }
    }



}
