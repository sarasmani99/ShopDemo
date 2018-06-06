using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace ShopDemo.Automation.Pages
{
    public class ItemsPage:Basepage
    {
        public ItemsPage(IAppDriver driver):base(driver)
        { }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Driver.AppUrl);
        }
        public enum AfterAddAction
        {
            ContinueShopping=1,
            ViewCart=2
        }

        public AfterAddAction cartOptions { get; set; }

        public void ClickProductCategory(string categoryName)
        {
            IWebElement categoryLink = FindByLinkText(categoryName);
            IWebElement parent = categoryLink.FindElement(By.ClassName("product-categories"));
            IWebElement link = parent.FindElement(By.LinkText(categoryName));
            link.Click();
        }

        public void AddItemsToCart(string itemName, AfterAddAction cartOption)
        {
            IWebElement item = FindByLinkText(itemName);
            IWebElement itemContainer = item.FindElement(By.XPath("../.."));

            //ScrollIntoView(itemContainer);
            Actions act = new Actions(Driver);
            act.MoveToElement(itemContainer).Build().Perform();

            Thread.Sleep(5000);
            var addToCartContainer = itemContainer.FindElement(By.ClassName("noo-loop-cart"));
            ExecuteScript("window.scrollTo(window.scrollX, window.scrollY-75)");
            
            addToCartContainer.Click();

            Thread.Sleep(10000);
            if (FindByClassName("mfp-content").Displayed)
            {
                var mainElement = FindByClassName("mfp-content");
               
                if (AfterAddAction.ContinueShopping == cartOption)
                {
                    var element = mainElement.FindElement(By.LinkText("CONTINUE SHOPPING"));
                    element.Click();
                }
                else if (AfterAddAction.ViewCart == cartOption)
                {
                    var element = mainElement.FindElement(By.LinkText("VIEW CART"));
                    element.Click();
                }
            }           
            
        }

        public List<string> GetAllItemNames()
        {
            var name = new List<string>();
            var elements = Driver.FindElements(By.ClassName("noo-product-thumbnail"));
            foreach (var element in elements)
            {
                var parentElement = element.FindElement(By.XPath(".."));
                var childElement = parentElement.FindElement(By.TagName("h3"));
                var ancElement = parentElement.FindElement(By.ClassName("noo-loop-cart"));
                var ancAttribute = ancElement.FindElement(By.TagName("a")).GetAttribute("href");
                
                if (ancAttribute.Contains("add-to-cart"))
                    name.Add(childElement.FindElement(By.TagName("a")).Text);
            }
            return name;
        }

        public bool FilterByColor(string color)
        {
            IWebElement dd= Driver.FindElement(By.Name("filter_color"));
            SelectElement ddElement = new SelectElement(Driver.FindElement(By.Name("filter_color")));
            ddElement.SelectByText(color);
            if (dd.Displayed)
                return true;
            else
                return false;
        }

        public void SearchForAnItem()
        {

        }
        
        public void FilterByPrice()
        {
            ExecuteScript("window.scrollTo(window.scrollX,window.scrollY+100)");
            var handles = Driver.FindElements(By.ClassName("ui-slider-handle")).ToArray();
            var handle1 = handles[0];
            var handle2 = handles[1];
            DragSlider(handle1, true, 40);
            DragSlider(handle2, false, 185);
        }

        private void DragSlider(IWebElement element, bool right, int value)
        {
            int offset = right ? 6 : -6;
            string handleIndex = right ? "0" : "1";
            int currentValue = int.Parse(ExecuteScript("return jQuery('.ui-slider').slider('option','values')["+handleIndex+"];").ToString());
            
            while (value != currentValue) 
            {
                Actions move = new Actions(Driver);
                move.MoveToElement(element)
                    .ClickAndHold(element)
                    .MoveByOffset(offset, 0)
                    .Release()
                    .Build()
                    .Perform();
                Thread.Sleep(100);
                currentValue = int.Parse(ExecuteScript("return jQuery('.ui-slider').slider('option','values')["+ handleIndex + "];").ToString());
                //Console.WriteLine(currentValue);
            }
            
        }
    }
}
