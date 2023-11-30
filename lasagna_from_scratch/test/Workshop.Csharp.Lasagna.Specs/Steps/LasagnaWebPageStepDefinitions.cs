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
        throw new PendingStepException();
    }

    [Then(@"os minutos restantes no forno devem ser 15 quando já se passaram 25")]
    public async Task Cenario2()
    {
        throw new PendingStepException();
    }

    [Then(@"os minutos restantes no forno devem ser 7 quando já se passaram 33")]
    public void Cenario3()
    {
        throw new PendingStepException();
    }

    [Then(@"o tempo de preparação em minutos deve ser 2 quando 1 camada é adicionada")]
    public void Cenario4()
    {
        throw new PendingStepException();
    }

    [Then(@"o tempo de preparação em minutos deve ser 4 quando 2 camadas são adicionadas")]
    public void Cenario5()
    {
        throw new PendingStepException();
    }

    [Then(
        @"o tempo decorrido em minutos deve ser 16 quando 3 camadas são adicionadas e já se passaram 10 minutos no forno"
    )]
    public void Cenario6()
    {
        throw new PendingStepException();
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
        _takeout;

    public LasagnaPageObject()
    {
        _driver = new ChromeDriver();
        AcessarPagina();
        _addedLayers = _driver.FindElement(By.Id("addedLayers"));
        _minutesInOven = _driver.FindElement(By.Id("minutesInOven"));
        _lasagnaButton = _driver.FindElement(By.Id("lasagna-button"));
        _takeout = _driver.FindElement(By.Id("takeout"));
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

    public void TempoDecorridoDeveSer(int minutos)
    {
        var value = _takeout.GetAttribute("value");
        value.Should().Be(minutos.ToString());
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
