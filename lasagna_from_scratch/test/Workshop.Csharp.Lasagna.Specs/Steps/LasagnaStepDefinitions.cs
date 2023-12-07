using TechTalk.SpecFlow;
using FluentAssertions;

namespace Workshop.Csharp.Lasagna.Specs.Steps;

[Binding]
[Scope(Tag = "usecase")]
public class LasagnaStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public LasagnaStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    // [Then(@"os minutos restantes no forno devem ser (.*) quando já se passaram (.*)")]
    // public void EntaoOsMinutosRestantesNoFornoDevemSerQuandoJaSePassaram(int p0, int p1)
    // {
    //     _scenarioContext.Pending();
    //     //throw new PendingStepException("sdtete");
    // }

    [Then(@"os minutos esperados no forno devem ser 40")]
    public void Cenario1()
    {
        var cut = new WebApi.Lasagna();
        cut.ExpectedMinutesInOven().Should().Be(40);
    }

    [Then(@"os minutos restantes no forno devem ser 15 quando já se passaram 25")]
    public void Cenario2()
    {
        var cut = new WebApi.Lasagna();
        cut.RemainingMinutesInOven(25).Should().Be(15);
    }

    [Then(@"os minutos restantes no forno devem ser 7 quando já se passaram 33")]
    public void Cenario3()
    {
        var cut = new WebApi.Lasagna();
        cut.RemainingMinutesInOven(33).Should().Be(7);
    }

    [Then(@"o tempo de preparação em minutos deve ser 2 quando 1 camada é adicionada")]
    public void Cenario4()
    {
        var cut = new WebApi.Lasagna();
        cut.PreparationTimeInMinutes(1).Should().Be(2);
    }

    [Then(@"o tempo de preparação em minutos deve ser 4 quando 2 camadas são adicionadas")]
    public void Cenario5()
    {
        var cut = new WebApi.Lasagna();
        cut.PreparationTimeInMinutes(2).Should().Be(4);
    }

    [Then(
        @"o tempo decorrido em minutos deve ser 16 quando 3 camadas são adicionadas e já se passaram 10 minutos no forno"
    )]
    public void Cenario6()
    {
        var cut = new WebApi.Lasagna();
        cut.ElapsedTimeInMinutes(3, 10).Should().Be(16);
    }

    [Then(
        @"o tempo decorrido em minutos deve ser 11 quando 2 camadas são adicionadas e já se passaram 7 minutos no forno"
    )]
    public void Cenario7()
    {
        var cut = new WebApi.Lasagna();
        cut.ElapsedTimeInMinutes(2, 7).Should().Be(11);
    }

    [Then(@"xxxos minutos restantes no forno devem ser (.*) quando já se passaram (.*)")]
    public void EntaoOsMinutosRestantesNoFornoDevemSerQuandoJaSePassaram(
        int minutesRestantes,
        int minutesDecorridos
    )
    {
        var cut = new WebApi.Lasagna();
        cut.RemainingMinutesInOven(minutesRestantes).Should().Be(minutesDecorridos);
    }

}
