using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marketplace;
using System.Text;

namespace TestMarketplace
{
    [TestClass]
    public class Tests 
    {
        Browser browser;
        [TestInitialize]
        public void ClassSetUp()
        {
            browser = new Browser();
        }

        [TestMethod]
        public void Go_To_First_App_Details_page()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            homepage.ClickPopularTab();
            string popularApp = homepage.GetMostPopularApp();
            homepage.SearchFor(popularApp);
            homepage.ClickFirstSearchResult();
            DetailsPage detailsPage = new DetailsPage(browser);
            Assert.IsTrue(detailsPage.Title().Contains(popularApp));
        }

        [TestMethod]
        public void Test_That_Promo_Box_Is_Visible()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            Assert.IsTrue(homepage.IsPromoBoxVisible());
            Assert.IsTrue(homepage.PromoBoxItemsNumber() > 0);
        }

        [TestMethod]
        public void Test_That_Header_Has_Expected_Items()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            Header header = new Header(browser);
            Assert.IsTrue(header.IsLogoVisible());
            Assert.IsTrue(header.IsSearchVisible());
            Assert.IsTrue(header.SearchFieldPlaceholder().Equals("Search the Marketplace"));
            Assert.IsTrue(header.IsSignInVisible());
        }

        [TestMethod]
        public void Test_That_Verifies_Nav_Menu()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            homepage.ClickNewTab();
            Assert.IsTrue("New" == homepage.FeedTitleText());
            Assert.IsTrue(homepage.AppsAreVisible());
            Assert.IsTrue(homepage.ElementsCount() > 0);

            homepage.ClickPopularTab();
            Assert.IsTrue("Popular" == homepage.FeedTitleText());
            Assert.IsTrue(homepage.AppsAreVisible());
            Assert.IsTrue(homepage.ElementsCount() > 0);
        }

        [TestMethod]
        public void Check_Categories_Menu()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            Categories cat = homepage.CheckCategories();
            Assert.IsTrue(cat.CategoriesNumber() > 0);
            Assert.IsTrue(cat.CategoriesDisplayed());
        }
        
        [TestMethod]
        public void Test_Report_Abuse_As_Anonymous_User()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            string SearchTerm = homepage.FirstAppName();
            homepage.SearchFor(SearchTerm);
            homepage.ClickFirstSearchResult();
            DetailsPage detailsPage = Pages.DetailsPage(browser);
            Assert.IsTrue(detailsPage.IsReportAbuseButtonVisible());
            ReportAbuse newP = detailsPage.ClickReportAbuseButton();
            Assert.IsTrue(newP.IsReportAbuseButtonVisble());
            newP.InsertText("This is an automatically generated report.");
            newP.ClickCancelButton();
        }

        [TestMethod]
        public void Test_Click_On_Content_Rating()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            string SearchTerm = homepage.FirstAppName();
            homepage.SearchFor(SearchTerm);
            homepage.ClickFirstSearchResult();
            DetailsPage detailsPage = Pages.DetailsPage(browser);
            ContentRating Rating = detailsPage.ClickRatingButton();
            Assert.IsTrue(Rating.IsRatingTableDisplayed());
        }

        [TestMethod]
        public void Test_Searching_With_Empty_Field_Using_Submit_Returns_Results()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());
            homepage.SearchFor("");
            Assert.IsTrue(homepage.SearchResultsNumber() > 0);
        }

        [TestMethod]
        public void Test_Search_Results()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            string SearchTerm = homepage.FirstAppName();
            Search searchpage = homepage.SearchFor(SearchTerm);
            searchpage.ClickExpandButton();
            foreach (SearchResults searchResult in searchpage.Results())
            {
                Assert.IsTrue(searchResult.IsInstallButtonDisplayed());
                Assert.IsTrue(searchResult.IsRatingDisplayed());
                Assert.IsTrue(searchResult.AreScreenshotsVisible());
            }
        }

        [TestMethod]
        public void Test_Search_Tag_Present_in_Search_Results()
        {
            HomePage homepage = Pages.HomePage(browser);
            homepage.GoTo();
            string SearchTerm = homepage.FirstAppName();
            Search searchpage = homepage.SearchFor(SearchTerm);
            Assert.IsTrue(searchpage.SearchResultsSectionTitle().Contains("results"));
            foreach (SearchResults searchResults in searchpage.Results())
            {
                if (SearchTerm == searchResults.Name())
                {
                    Assert.AreEqual(SearchTerm, searchResults.Name());
                }
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.browser.Dispose();
        }
    }
}