using TechTalk.SpecFlow;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
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
    public async Task Cenario2()
    {
        var actualExpectedMinutes = await _client.GetStringAsync("/api/lasagna/times/remaining?actualMinutes=25");
        actualExpectedMinutes.Should().Be("15");
    }

    [Then(@"os minutos restantes no forno devem ser 7 quando já se passaram 33")]
    public async Task Cenario3()
    {
        var actualExpectedMinutes = await _client.GetStringAsync("/api/lasagna/times/remaining?actualMinutes=33");
        actualExpectedMinutes.Should().Be("7");
    }

    [Then(@"o tempo de preparação em minutos deve ser 2 quando 1 camada é adicionada")]
    public async Task Cenario4()
    {
        var actualPreparationMinutes = await _client.GetStringAsync("/api/lasagna/times/preparation?addedLayers=1");
        actualPreparationMinutes.Should().Be("2");
    }

    [Then(@"o tempo de preparação em minutos deve ser 4 quando 2 camadas são adicionadas")]
    public async Task Cenario5()
    {
        var actualPreparationMinutes = await _client.GetStringAsync("/api/lasagna/times/preparation?addedLayers=2");
        actualPreparationMinutes.Should().Be("4");
    }

    [Then(
        @"o tempo decorrido em minutos deve ser 16 quando 3 camadas são adicionadas e já se passaram 10 minutos no forno"
    )]
    public async Task Cenario6()
    {
        var actualExpectedMinutes = await _client.GetStringAsync("/api/lasagna/times/elapsed?addedLayers=1&minutesInOven=10");
        actualExpectedMinutes.Should().Be("12");
    }

    [Then(
        @"o tempo decorrido em minutos deve ser 11 quando 2 camadas são adicionadas e já se passaram 7 minutos no forno"
    )]
    public async Task Cenario7()
    {
        var actualExpectedMinutes = await _client.GetStringAsync("/api/lasagna/times/elapsed?addedLayers=2&minutesInOven=7");
        actualExpectedMinutes.Should().Be("11");
    }

}