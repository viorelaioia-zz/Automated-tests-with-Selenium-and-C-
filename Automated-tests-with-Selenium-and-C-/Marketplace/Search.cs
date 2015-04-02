using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections;

namespace Marketplace
{
    /*!
     *  \brief      Search page class
     *  \details    The class contains members that retrun/make an action on the search page elements
     *  \author     Viorela Ioia
     *  \version    1.0a
     *  \date       3/31/2015
     *  \warning    None
     */

    public class Search
    {
        private Browser browser; /*!< detailed description */

        public Search(Browser browser)
        {
            this.browser = browser;
        }

        public void ClickExpandButton()
        {
            browser.Driver.FindElement(By.CssSelector("#search-results .app-list-filters-expand-toggle")).Click();
        }



        public IEnumerable<SearchResults> Results()
        { 
            foreach (IWebElement websth in browser.Driver.FindElements(By.CssSelector("#search-results .item.result.app-list-app")))
            {
                yield return new SearchResults(this.browser, websth);
            }
        }

        public string SearchResultsSectionTitle()
        {
            return browser.Driver.FindElement(By.CssSelector(".search-results-header-desktop")).Text;
        }
    }
}
