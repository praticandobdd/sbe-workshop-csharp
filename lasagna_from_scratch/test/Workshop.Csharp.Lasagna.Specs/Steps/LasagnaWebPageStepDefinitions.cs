using TechTalk.SpecFlow;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.OpenApi.Writers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Workshop.Csharp.Lasagna.Specs.Steps;

[Binding]
[Scope(Tag = "webpage")]
public class LasagnaWebPageStepDefinitions
{
    [Then(@"os minutos esperados no forno devem ser 40")]
    public async Task Cenario1()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.SubmeterTempoEsperado();
        pageObject.TempoEsperadoDeveSer(40);
        pageObject.Dispose();
    }

    [Then(@"os minutos restantes no forno devem ser 15 quando já se passaram 25")]
    public async Task Cenario2()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.InformarMinutosNoForno(25);
        pageObject.SubmeterTempoRestante();
        pageObject.TempoRestanteDeveSer(15);
        pageObject.Dispose();
    }

    [Then(@"os minutos restantes no forno devem ser 7 quando já se passaram 33")]
    public void Cenario3()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.InformarMinutosNoForno(33);
        pageObject.SubmeterTempoRestante();
        pageObject.TempoRestanteDeveSer(7);
        pageObject.Dispose();
    }

    [Then(@"o tempo de preparação em minutos deve ser 2 quando 1 camada é adicionada")]
    public void Cenario4()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.InformarCamada(1);
        pageObject.SubmeterTempoDePreparacao();
        pageObject.TempoDePreparacaoDeveSer(2);
        pageObject.Dispose();
    }

    [Then(@"o tempo de preparação em minutos deve ser 4 quando 2 camadas são adicionadas")]
    public void Cenario5()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.InformarCamada(2);
        pageObject.SubmeterTempoDePreparacao();
        pageObject.TempoDePreparacaoDeveSer(4);
        pageObject.Dispose();
    }

    [Then(
        @"o tempo decorrido em minutos deve ser 16 quando 3 camadas são adicionadas e já se passaram 10 minutos no forno"
    )]
    public void Cenario6()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.InformarCamada(3);
        pageObject.InformarMinutosNoForno(10);
        pageObject.Submeter();
        pageObject.TempoDecorridoDeveSer(16);
        pageObject.Dispose();
   }

    [Then(
        @"o tempo decorrido em minutos deve ser 11 quando 2 camadas são adicionadas e já se passaram 7 minutos no forno"
    )]
    public void Cenario7()
    {
        var pageObject = new LasagnaPageObject();
        pageObject.InformarCamada(2);
        pageObject.InformarMinutosNoForno(7);
        pageObject.Submeter();
        pageObject.TempoDecorridoDeveSer(11);
        pageObject.Dispose();
    }
}

class LasagnaPageObject : System.IDisposable 
{
    private readonly WebDriver _driver;
    private readonly IWebElement _addedLayers,
        _minutesInOven,
        _lasagnaButton,
        _lasagnaPreparationTimeButton,
        _lasagnaRemainingTimeButton,
        _lasagnaExpectedTimeButton,
        _takeout;

    public LasagnaPageObject()
    {
    try {
        _driver = new ChromeDriver();
        AcessarPagina();
        _addedLayers = _driver.FindElement(By.Id("addedLayers"));
        _minutesInOven = _driver.FindElement(By.Id("minutesInOven"));
        _lasagnaButton = _driver.FindElement(By.Id("lasagna-button"));
        _lasagnaExpectedTimeButton = _driver.FindElement(By.Id("lasagna-expected-time-button"));
        _lasagnaPreparationTimeButton = _driver.FindElement(By.Id("lasagna-preparation-time-button"));
        _lasagnaRemainingTimeButton = _driver.FindElement(By.Id("lasagna-remaining-time-button"));
        _takeout = _driver.FindElement(By.Id("takeout"));
        } catch (System.Exception e){
            var trace = e.StackTrace;
        }
    }

    public void AcessarPagina()
    {
        _driver.Navigate().GoToUrl("http://127.0.0.1:8080/lasagna.html");
    }

    public void InformarCamada(int camadas)
    {
        _addedLayers.SendKeys(camadas.ToString());
    }

    public void InformarMinutosNoForno(int minutos)
    {
        _minutesInOven.SendKeys(minutos.ToString());
    }

    public void Submeter()
    {
        _lasagnaButton.Click();
    }

    public void SubmeterTempoDePreparacao()
    {
        _lasagnaPreparationTimeButton.Click();
    }

    public void SubmeterTempoRestante()
    {
        _lasagnaRemainingTimeButton.Click();
    }

    public void SubmeterTempoEsperado()
    {
        _lasagnaExpectedTimeButton.Click();
    }

    public void TempoDecorridoDeveSer(int minutos)
    {
        var value = _takeout.GetAttribute("value");
        value.Should().Be(minutos.ToString());
    }

     public void TempoDePreparacaoDeveSer(int minutos)
    {
        var value = _takeout.GetAttribute("value");
        value.Should().Be(minutos.ToString());
    }

     public void TempoRestanteDeveSer(int minutos)
    {
        var value = _takeout.GetAttribute("value");
        value.Should().Be(minutos.ToString());
    }

     public void TempoEsperadoDeveSer(int minutos)
    {
        var value = _takeout.GetAttribute("value");
        value.Should().Be(minutos.ToString());
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
