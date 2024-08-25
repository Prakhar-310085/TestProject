using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        private string _url;
        private string _username;
        private string _password;
        [SetUp]
        public void Setup()
        {
            _url = "https://www.saucedemo.com/";
            _username = ConfigurationManager.AppSettings["Username"];
            _password = ConfigurationManager.AppSettings["Password"];
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.Login(_username, _password);
            HomePage homePage = new HomePage(_driver);
            Assert.IsTrue(homePage.Ishomepagedisplayed(), "Home page unavailable afer Login");
            homePage.OpenBurgerMenu();
            Assert.IsTrue(homePage.IsBurgerMenuOpen(), "Burger menu did not open");
            homePage.Cartisempty();
            Assert.IsTrue(homePage.Cartisempty(), "cart is not empty");
            string productName = "Sauce Labs Backpack";
            string addedProductName = homePage.GetProductNameAndAddToCart(productName);
            homePage.OpenCart();
            Assert.IsTrue(homePage.IsProductInCart(addedProductName), $"Selected product '{addedProductName}' is not in the cart");
            Checkout checkout = new Checkout(_driver);
            checkout.Checkoutbuttonclick();
            checkout.EnterDetails();
            Assert.IsTrue(_driver.PageSource.Contains("Thank you for your order!"));
        }
        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}