using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation.VisualStudioTest.PageFactory
{
    public static class Provider
    {
        public static IAppDriver CreateDriver()
        {
            IAppDriver driver = null;
            var browser = System.Environment.GetEnvironmentVariable("browser");
            if (browser == "chrome")
                driver = new AppChromeDriver();
            else if (browser == "Firefox")
                driver = new AppFirefoxDriver();
            else if (browser == "Edge")
                driver = new AppEdgeDriver();

            return driver;

        }

        

       
    }
}
