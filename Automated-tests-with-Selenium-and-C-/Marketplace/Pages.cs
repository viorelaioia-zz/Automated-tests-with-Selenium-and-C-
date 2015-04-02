using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;


namespace Marketplace
{
    public static class Pages
    {
        public static HomePage HomePage(Browser browser)
        {
            var homePage = new HomePage(browser);
            PageFactory.InitElements(browser.Driver, homePage);
            return homePage;
        }

        public static DetailsPage DetailsPage(Browser browser)
        {
            var detailsPage = new DetailsPage(browser);
            PageFactory.InitElements(browser.Driver, detailsPage);
            return detailsPage;
        }
    }
}
