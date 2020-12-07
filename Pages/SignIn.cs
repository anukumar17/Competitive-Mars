using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            // extent reports
            Base.test = Base.extent.StartTest("Login steps test");

            // Populate the data in excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            // Wait Element
            //GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//a[contains(text(),'Sign')]", 10);

            // Click signin tab to signin page
            SignIntab.Click();

            // Input ussername
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            // input password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click login button
            LoginBtn.Click();

            // Verify the login status 
            Thread.Sleep(5000);
            //GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']" +
               // "//div[1]/div[2]/div/span", 10);         

         
            var greeting = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']//div[1]/div[2]/div/span")).Text;
            //Assert.That(loginName, Contains.Substring("Zorawar Badhan"));
            if (greeting.Contains("Hi"))
            {
                Base.test.Log(LogStatus.Pass, "Login Successful");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Login failed");
            }

        }
    }
}



