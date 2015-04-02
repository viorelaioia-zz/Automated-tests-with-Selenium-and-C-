using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Marketplace
{
    public class DetailsPage
    {
        Browser browser;
        WebDriverWait wait;
        public DetailsPage(Browser browser)
        {
            this.browser = browser;
            this.wait = new WebDriverWait(this.browser.Driver, TimeSpan.FromSeconds(3));
        }

        public string Title()
        {
            return browser.Title;
        }

        public bool IsReportAbuseButtonVisible()
        {
            return browser.Driver.FindElement(By.CssSelector(".button.abuse")).Displayed;
        }

        public ReportAbuse ClickReportAbuseButton()
        {
            IWebElement ReportAbuseButton = browser.Driver.FindElement(By.CssSelector(".button.abuse"));
            ((IJavaScriptExecutor)browser.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", ReportAbuseButton);
            ReportAbuseButton.Click();
            return new ReportAbuse(this.browser);
        }

        public ContentRating ClickRatingButton()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".content-ratings-wrapper .button")));
            IWebElement RatingButton = browser.Driver.FindElement(By.CssSelector(".content-ratings-wrapper .button"));
            ((IJavaScriptExecutor)browser.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", RatingButton);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".content-ratings-wrapper .button")));
            RatingButton.Click();
            return new ContentRating(this.browser);
        }
    }

    public class ReportAbuse
    {
        Browser browser;
        public ReportAbuse(Browser browser)
        {
            this.browser = browser;
        }

        public bool IsReportAbuseButtonVisble()
        {
            return browser.Driver.FindElement(By.CssSelector("button[type='submit']")).Displayed;
        }

        public bool IsReportAbuseButtonEnabled()
        {
            return browser.Driver.FindElement(By.CssSelector("button[type='submit']")).Enabled;
        }

        public void ClickCancelButton()
        {
            browser.Driver.FindElement(By.CssSelector("button[data-type='cancel']")).Click();
        }

        public void InsertText(string Text)
        {
            browser.Driver.FindElement(By.CssSelector(".abuse-form > textarea")).SendKeys(Text);
        }
    }

    public class ContentRating
    {
        Browser browser;
        private static string PageTitle = "IARC Ratings Guide | International Age Rating Coalition";

        public ContentRating(Browser browser)
        {
            this.browser = browser;
            string NewTab = browser.Driver.WindowHandles[1];
            browser.Driver.SwitchTo().Window(NewTab).Title.Equals(PageTitle);
        }

        public bool IsRatingTableDisplayed()
        {
            return browser.Driver.FindElement(By.CssSelector(".ratings")).Displayed;
        }
    }
}
