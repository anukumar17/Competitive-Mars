using System;
using MarsFramework.Global;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region initialized Web Element

        #region Initialize web elements
        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//input[@value='']")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement Servicetyp { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement LocationSel { get; set; }


        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@name='Available'])[2]")]
        private IWebElement Day { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "(//input[@name='StartTime'])[2]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Storing the Endtime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement EndTime { get; set; }

        //Click on EndtTime dropdown
        [FindsBy(How = How.XPath, Using = "(//input[@name='EndTime'])[2]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement SkillExchange { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement HiddenOpt { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Validate share skill details
        //Click on manage listing
        [FindsBy(How = How.XPath, Using = "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[2]/button[2]")]
        private IWebElement ManageLis { get; set; }


        #endregion 



        internal void VerifyShareSkill()
        {
           
        }


        internal void AddShareSkill()
        {
            //populate excel data 

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            try
            {

                //Click on Share skill button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Share Skill", 10000);
                ShareSkillButton.Click();

                //Enter the Title in textbox
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
                Title.Click();
                Title.Clear();
                Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

                //Enter the Description in textbox
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "description", 10000);
                Description.Click();
                Description.Clear();
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

                //Select catagory from drop down
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "categoryId", 10000);
                CategoryDropDown.Click();
                new SelectElement(CategoryDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

                //Select catagory from drop down
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "subcategoryId", 10000);
                SubCategoryDropDown.Click();
                new SelectElement(SubCategoryDropDown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

                //Enter Tag names in textbox
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='']", 10000);
                Tags.Click();
                Tags.Clear();
                Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);

                //Select service type
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']", 10000);
                ServiceTypeOptions.Click();
                Servicetyp.Click();

                //Select the Location Type
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']", 10000);
                LocationTypeOption.Click();
                LocationSel.Click();

                //Add start date
                StartDateDropDown.Click();
                // StartDateDropDown.Clear();
                StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

                //Add End date
                EndDateDropDown.Click();
                //EndDateDropDown.Clear();
                EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));


                //Select available day
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]", 10000);
                Days.Click();
                Day.Click();

                //Select start time
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input", 10000);
                StartTime.Click();


                //enter start time
                StartTimeDropDown.Click();
                //StartTimeDropDown.Clear();
                StartTimeDropDown.SendKeys("08:00 AM");//(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

                //Select end time
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input", 10000);
                EndTime.Click();

                //Enter end time
                EndTimeDropDown.Click();
                //EndTimeDropDown.Clear();
                EndTimeDropDown.SendKeys("05:00 PM");// (GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

                //Click on Skill trade option
                SkillTradeOption.Click();

                //Add Skill exchange tag
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input", 10000);
                SkillExchange.Click();
                SkillExchange.Clear();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);

                //Select option Active or Hidden
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']", 10000);
                ActiveOption.Click();
                HiddenOpt.Click();

                //Click on save button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Save']", 10000);
                Save.Click();
            }

            catch (Exception ex)
            {
                Assert.Fail("Test failed to enter Skill details", ex.Message);
            }
        }

    }
    #endregion

   


    }


