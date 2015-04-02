using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using OpenQA.Selenium.Interactions;

namespace Marketplace
{
    public class HomePage
    {
        Browser browser;
        WebDriverWait wait;
        Actions actions;
        static string Url = "https://marketplace.firefox.com/";
        private static string PageTitle = "Firefox Marketplace";

        public HomePage(Browser browser)
        {
            this.browser = browser;
            wait = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(3));
            this.actions = new Actions(browser.Driver);
        }

        public void GoTo()
        {
            browser.Goto(Url);
        }

        public bool IsAt()
        {
            return browser.Title == PageTitle;
        }

        public void ClickPopularTab()
        {
            browser.Driver.FindElement(By.XPath(".//*[@id='site-nav']/ul[1]/li[3]/a")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".pretty-select-wrapper")));
        }

        public void ClickNewTab()
        {
            browser.Driver.FindElement(By.XPath(".//*[@id='site-nav']/ul[1]/li[2]/a")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".pretty-select-wrapper")));
        }

        public string FirstAppName()
        {
            return browser.Driver.FindElement(By.CssSelector(".product .info>h3")).Text;
        }

        public Categories CheckCategories()
        {
            IWebElement category = browser.Driver.FindElement(By.XPath(".//*[@id='site-nav']/ul[1]/li[5]/a[2]"));
            actions.MoveToElement(category).Build().Perform();
            return new Categories(browser.Driver);
        }

        public string GetMostPopularApp()
        {
            return browser.Driver.FindElement(By.CssSelector(".info>h3")).Text;
        }

        public Search SearchFor(string searchTerm)
        {
            browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement search = browser.Driver.FindElement(By.Id("search-q"));
            search.SendKeys(searchTerm);
            search.SendKeys(Keys.Enter);
            browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#search-results>div")));
            return new Search(this.browser);
        }

        public void ClickFirstSearchResult()
        {
            browser.Driver.FindElement(By.CssSelector(".info>h3")).Click();
        }

        public int SearchResultsNumber()
        {
            return browser.Driver.FindElements(By.CssSelector(".item.result.app-list-app")).Count;
        }

        public bool IsPromoBoxVisible()
        {
            return browser.Driver.FindElement(By.CssSelector(".desktop-promo")).Displayed;
        }

        public int PromoBoxItemsNumber()
        {
            return browser.Driver.FindElements(By.CssSelector(".desktop-promo-item")).Count;
        }

        public string FeedTitleText()
        {
            return browser.Driver.FindElement(By.CssSelector(".subheader > h1")).Text;
        }

        public bool AppsAreVisible()
        {
            return browser.Driver.FindElement(By.CssSelector(".app-list-app")).Displayed;
        }

        public int ElementsCount()
        {
            return browser.Driver.FindElements(By.CssSelector(".app-list-app")).Count;
        }
 
    }

    public class Categories
    {
        private IWebDriver webDriver;

        public Categories(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string Title()
        {
            return webDriver.FindElement(By.CssSelector(".desktop-cat-link")).Text;
        }

        public bool IsTitleVisible()
        {
            return webDriver.FindElement(By.CssSelector(".desktop-cat-link")).Displayed;
        }

        public int CategoriesNumber()
        {
            return webDriver.FindElements(By.CssSelector(".hovercats li")).Count;
        }

        public bool CategoriesDisplayed()
        {
            IReadOnlyCollection<IWebElement> items = webDriver.FindElements(By.CssSelector(".hovercats li"));

            return items.All(x => x.Displayed);
        }
    }
}