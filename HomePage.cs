using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class HomePage
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        
        public HomePage(IWebDriver driver)
        {
            _driver=driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement Homepagetitle => _driver.FindElement(By.XPath("//title[contains(text(), 'Swag Labs')]"));
        private IWebElement productTitle => _driver.FindElement(By.XPath("//span[@class='title' and text()='Products']"));
        private IWebElement Burgermenubutton => _driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
        private IWebElement BurgerMenuCloseButton => _driver.FindElement(By.Id("react-burger-cross-btn"));
        private IWebElement ResetAppStateLink => _driver.FindElement(By.Id("reset_sidebar_link"));
        private IWebElement CartItemCount => _driver.FindElement(By.ClassName("shopping_cart_badge"));//counter increase if we click on Add to cart
        private IWebElement CartButton => _driver.FindElement(By.Id("shopping_cart_container"));
        public bool Ishomepagedisplayed()
        {
            return productTitle.Displayed && productTitle.Text.Contains("Products");
        }
        public void OpenBurgerMenu()
        {
            Burgermenubutton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("react-burger-cross-btn")));
        }

        public bool IsBurgerMenuOpen()
        {
            return BurgerMenuCloseButton.Displayed;
        }
        public void ResetAppState()
        {
            ResetAppStateLink.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("shopping_cart_badge")));
        }
        public bool Cartisempty()
        {
            try
            {
                return !CartItemCount.Displayed || CartItemCount.Text == "0";
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
        public string GetProductNameAndAddToCart(string productName)
        {
            var productElement = _driver.FindElement(By.XPath($"//div[text()='{productName}']/ancestor::div[@class='inventory_item']//button"));
            var productNameElement = _driver.FindElement(By.XPath($"//div[text()='{productName}']"));

            string name = productNameElement.Text;
            productElement.Click();
            return name;
        }

        public void OpenCart()
        {
            CartButton.Click();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("cart_item")));
        }
        public bool IsProductInCart(string productName)
        {
            var productInCart = _driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']"));
            return productInCart.Displayed;
        }

    }
}
