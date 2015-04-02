using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace
{
    public class Header
    {
        Browser browser;
        public Header(Browser browser)        
        {
            this.browser = browser;
        }

        public bool IsLogoVisible()
        {
            return browser.Driver.FindElement(By.CssSelector(".site > a")).Displayed;
        }

        public bool IsSearchVisible()
        {
            return browser.Driver.FindElement(By.Id("search-q")).Displayed;
        }

        public bool IsSignInVisible()
        {
            return browser.Driver.FindElement(By.CssSelector(".header-button.persona:not(.register)")).Displayed;
        }

        public string SearchFieldPlaceholder()
        {
            return browser.Driver.FindElement(By.Id("search-q")).GetAttribute("placeholder");
        }
    }
}
