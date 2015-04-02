using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Marketplace
{
    public class Browser
    {
        IWebDriver webDriver; 
        public Browser(string BrowserType = "Chrome")
        {
            switch (BrowserType)
            { 
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }         
        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public IWebDriver Driver
        {
            get { return webDriver; }
        }

        public void Goto(string url)
        {
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            webDriver.Url = url;
        }

        public void Close()
        {
            webDriver.Close();
        }

        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}
