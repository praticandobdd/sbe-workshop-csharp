using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using FluentAssertions;

namespace Workshop.Csharp.Lasagna.Specs.Lasagna;

public class LasagnaWebTests {

  [Fact]
    public void ShouldSearchOnGoogle()
    {
        using (var driver = new ChromeDriver()) {
            driver.Navigate().GoToUrl("https://selenium.dev");
            driver.Url = "https://www.google.com";
            driver.FindElement(By.Name("q")).SendKeys("webdriver" + Keys.Return);
            driver.Title.Should().Be("webdriver - Pesquisa Google");
            driver.Navigate().GoToUrl("https://localhost:5280");
        }
    }

  [Fact]
        public void ShowLasagnaTimes()
    {
        using (var driver = new ChromeDriver()) {
            driver.Navigate().GoToUrl("https://localhost:5280");
            driver.Should().NotBeNull();
        }
    }
            
}
