using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture, Description("this fixture contains mars framework")]
        [Category("Sprint1")]
        class User : Global.Base
        {
            #region Profile page

            [Test, Description("check if the user is able to add the profile detail sucessfully")]
            public void ProfileDetail()
            { 
                //create extent report
                test = extent.StartTest("Add Profile");
                //Add Profile
                Profile profileObj = new Profile();
                profileObj.AddProfile();
                profileObj.VerifyProfile();

            }

            #endregion

            #region Skill Share

            [Test, Description("check if the user is able to share the skill successfuly")]
            public void ShareSkill()
            {
                //create extent report
                test = extent.StartTest("Add share skill");
                //Add Profile
                ShareSkill ShareSkillObj = new ShareSkill();
                ShareSkillObj.AddShareSkill();
                ShareSkillObj.VerifyShareSkill();

            }
            #endregion

            #region Manage Listings
            [Test, Description("check if the user is able to add the Manage Listing sucessfully")]
            public void ManageListings()
            {
                ManageListings manageListingsobj = new ManageListings();
                manageListingsobj.ViewManageListings();
                manageListingsobj.EditManageListings();
                manageListingsobj.VerifyEditManageListings();
                manageListingsobj.DeleteManageLsitings();
                manageListingsobj.VerifyDeleteManageListings();
            }
            #endregion
        }
    }
}
