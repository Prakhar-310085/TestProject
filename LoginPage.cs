using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement UserNameField => _driver.FindElement(By.XPath("//input[@id='user-name']"));
        private IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@id='login-button']"));
        public void Login(string username, string password)
        {
            UserNameField.SendKeys("standard_user");
            PasswordField.SendKeys("secret_sauce");
            LoginButton.Click();
        }
    }
}
