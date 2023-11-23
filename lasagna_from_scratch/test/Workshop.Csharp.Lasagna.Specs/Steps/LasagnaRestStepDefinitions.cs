using TechTalk.SpecFlow;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
using Xunit;
using Microsoft.OpenApi.Writers;


namespace Workshop.Csharp.Lasagna.Specs.Steps;

[Binding]
[Scope(Tag = "webapi")]
public class LasagnaRestStepDefinitions
{

 private readonly HttpClient _client;
    public LasagnaRestStepDefinitions()
    {
        var factory = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>();
        _client = factory.CreateDefaultClient();
    }

    [Then(@"os minutos esperados no forno devem ser 40")]
    public async Task Cenario1()
    {
        var actualExpectedMinutes = await _client.GetStringAsync("/api/lasagna/times/expected");
        actualExpectedMinutes.Should().Be("40");
    }

    [Then(@"os minutos restantes no forno devem ser 15 quando já se passaram 25")]
    public void Cenario2()
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
        throw new PendingStepException();
    }

}