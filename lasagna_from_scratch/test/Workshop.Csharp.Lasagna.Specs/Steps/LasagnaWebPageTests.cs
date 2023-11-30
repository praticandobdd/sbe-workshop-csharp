using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using FluentAssertions;

namespace Workshop.Csharp.Lasagna.Specs.Steps;

public class LasagnaWebPageStepTests 
{

  [Fact]
  [Trait("webpages","lasagna")]
        public void ShowLasagnaTimes()
    {
        using (var driver = new ChromeDriver()) {
            //TODO cenário [1|2|3|4|5|6|7]
            //Então o tempo decorrido em minutos deve ser 11 
            //quando 2 camadas são adicionadas e
            // já se passaram 7 minutos no forno
            driver.Navigate().GoToUrl("http://127.0.0.1:8080/lasagna.html");
            var addedLayers = driver.FindElement(By.Id("addedLayers"));
            addedLayers.SendKeys("2");
            var minutesInOven = driver.FindElement(By.Id("minutesInOven"));
            minutesInOven.SendKeys("7");
            var lasagnaButton = driver.FindElement(By.Id("lasagna-button"));
            lasagnaButton.Click();
            var takeout = driver.FindElement(By.Id("takeout"));
            //var value = takeout.Text;
            var value = takeout.GetAttribute("value");
            value.Should().Be("11");
            //<input class="form-control form-control-lg" id="addedLayers" name="addedLayers" placeholder="Added Layers">
            //<input class="form-control form-control-lg" id="minutesInOven" name="minutesInOven" placeholder="Minutes in oven">
            //<button id="lasagna-button" type="submit" class="btn  btn-primary" onclick="callLasagna(); return false;"><i class="bi-plus-circle"></i> Calculate</button>
            //<button id="reset-lasagna-button" type="submit" class="btn" onclick="reset(); return false;"><i class="bi-x-circle" style="color:red"></i> Reset</button>
            //<input type="text" class="form-control form-control-lg" id="takeout" readonly="">
        }
    }
}