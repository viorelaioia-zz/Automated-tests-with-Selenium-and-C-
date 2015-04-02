using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace
{
    public class SearchResults
    {
        private Browser browser;
        private IWebElement websth;

        public SearchResults(Browser browser)
        {
            this.browser = browser;
        }

        public SearchResults(Browser browser, IWebElement websth)
        {
            this.browser = browser;
            this.websth = websth;
        }

        public bool IsInstallButtonDisplayed()
        {
            return websth.FindElement(By.CssSelector(".button.install")).Displayed;
        }

        public string Name()
        {
            return websth.FindElement(By.CssSelector(".info > h3")).Text;
        }

        public bool AreScreenshotsVisible()
        {
            return websth.FindElement(By.CssSelector(".button.install")).Displayed;
        }

        public bool IsRatingDisplayed()
        {
            return websth.FindElement(By.CssSelector(".stars")).Displayed;
        }
    }
}
