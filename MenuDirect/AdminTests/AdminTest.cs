using MenuDirect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdminTests
{
    
    
    /// <summary>
    ///This is a test class for AdminTest and is intended
    ///to contain all AdminTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdminTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAdminInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MenuDirect.exe")]
        public void GetAdminInputTest()
        {
            Menu menu = new Menu();
            MenuDirect.Admin target = new MenuDirect.Admin(menu); // TODO: Initialize to an appropriate value
            String expected = "2"; // TODO: Initialize to an appropriate value
            String actual;
            actual = target.GetAdminInput("2");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PrintAdminChoices
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MenuDirect.exe")]
        public void PrintAdminChoicesTest()
        {
            Menu menu = new Menu();
            Admin_Accessor target = new Admin_Accessor(menu); // TODO: Initialize to an appropriate value
            target.PrintAdminChoices();
            Assert.Inconclusive();
        }

        /// <summary>
        ///A test for GetAdminChoice
        ///</summary>
        [TestMethod()]
        public void GetAdminChoiceTest()
        {
            Menu menu = new Menu();
            Admin target = new Admin(menu); // TODO: Initialize to an appropriate value
            char adminChoice = '\0'; // TODO: Initialize to an appropriate value
            target.GetAdminChoice(adminChoice);
        }
    }
}
