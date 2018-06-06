using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation
{
    public interface IAppDriver:IWebDriver
    {
        string AppUrl { get; set; }
    }

    public class AppChromeDriver : ChromeDriver, IAppDriver
    {
        public string AppUrl { get; set; }
    }

    public class AppFirefoxDriver: OpenQA.Selenium.Firefox.FirefoxDriver, IAppDriver
    {
        public string AppUrl { get; set; }
    }
    public class AppEdgeDriver : OpenQA.Selenium.Edge.EdgeDriver, IAppDriver
    {
        public string AppUrl { get; set; }
    }
}
