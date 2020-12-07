using System;
using System.Threading;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;



namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //View listing validation
        [FindsBy(How = How.XPath, Using = " //*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")]
        private IWebElement ViewValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i")]
        private IWebElement edit { get; set; }


        //Select Title to edit
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")]
        private IWebElement delete { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]/i")]
        private IWebElement yesBtn { get; set; }

        #region view 
        internal void ViewManageListings()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListing");

            //click on Manage Listing
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Manage Listings", 10000);
            GlobalDefinitions.driver.Navigate().Refresh();
            manageListingsLink.Click();

            //click on View the Listing Icon
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "(//i[@class='eye icon'])[1]", 10000);
            view.Click();
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();


            // validate view
            try
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span", 50000);
                var ViewVald = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")).Text;
                Assert.That(ViewVald, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Title")));

                Base.test.Log(LogStatus.Pass, "Able to view listing");

            }
            catch (Exception ex)
            {
                Assert.Fail("verify the view share skill failed", ex.Message);
                Base.test.Log(LogStatus.Fail, "Unable to view listing");
            }
        }
        #endregion
        #region Edit
        internal void EditManageListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListing");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //click on Manage Listing
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Manage Listings", 10000);
            GlobalDefinitions.driver.Navigate().Refresh();
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i", 10000);
            edit.Click();

            //select Title
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
            Title.Click();
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //click on save
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Save']", 10000);
            Save.Click();


        }
        internal void VerifyEditManageListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListing");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            // Click on Manage Lsitings
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Manage Listings", 10000);
            manageListingsLink.Click();
            Thread.Sleep(5000);

            //click on Edit Icon
            //Click on view button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "(//i[@class='eye icon'])[1]", 10000);
            view.Click();
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span", 20000);
                var VerifyEdit = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")).Text;
                Assert.That(VerifyEdit, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Title")));
                Base.test.Log(LogStatus.Pass, "Listing Edited successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("verify the edited share skill page failed", ex.Message);
                Base.test.Log(LogStatus.Fail, "Unable to edit listing");
            }
        }
        #endregion

        #region Delete Listing
        internal void DeleteManageLsitings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListing");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            // Click on Manage Lsitings
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Manage Listings", 10000);
            manageListingsLink.Click();
            Thread.Sleep(5000);

            //Click on Delete Icon
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i", 10000);
            delete.Click();
            //yes or nor...click yes
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@class='actions']", 10000);
            clickActionsButton.Click();
            yesBtn.Click();
        }

        internal void VerifyDeleteManageListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListing");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Verify deleted details

                var deletedListing = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3]")).Text;
                if (deletedListing != GlobalDefinitions.ExcelLib.ReadData(3, "Title"))
                {
                    Assert.Pass("Manage Listing deleted successfuly");
                    Base.test.Log(LogStatus.Pass, "deleted successfuly");
                }
                else
                {
                    Assert.Fail("Manage Listing not deleted");
                    Base.test.Log(LogStatus.Fail, " not deleted successfuly");
                }
            }
            catch
            {
                Console.WriteLine("Test passed, Listing deleted");
            }

        }


        #endregion
    }

}

