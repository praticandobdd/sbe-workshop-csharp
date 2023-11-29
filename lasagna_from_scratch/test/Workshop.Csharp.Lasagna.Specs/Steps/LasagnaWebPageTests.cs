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
            driver.Navigate().GoToUrl("http://127.0.0.1:8080/lasagna.html");
            driver.Should().NotBeNull();
            //<input class="form-control form-control-lg" id="addedLayers" name="addedLayers" placeholder="Added Layers">
            //<input class="form-control form-control-lg" id="minutesInOven" name="minutesInOven" placeholder="Minutes in oven">
            //<button id="lasagna-button" type="submit" class="btn  btn-primary" onclick="callLasagna(); return false;"><i class="bi-plus-circle"></i> Calculate</button>
            //<button id="reset-lasagna-button" type="submit" class="btn" onclick="reset(); return false;"><i class="bi-x-circle" style="color:red"></i> Reset</button>
            //<input type="text" class="form-control form-control-lg" id="takeout" readonly="">
        }
    }
}