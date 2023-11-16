using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Workshop.Csharp.Lasagna.Specs.Steps;

[Binding]
public sealed class LasagnaStepDefinitions
{
    private readonly IUnitTestRuntimeProvider _unitTestRuntimeProvider;
    private readonly ScenarioContext _scenarioContext;

    public LasagnaStepDefinitions(
        IUnitTestRuntimeProvider unitTestRuntimeProvider,
        ScenarioContext scenarioContext
    )
    {
        _unitTestRuntimeProvider = unitTestRuntimeProvider;
        _scenarioContext = scenarioContext;
    }

    [Then("expected minutes in oven should be 40")]
    public void ThenExpectedMinutesInOvenShouldBe40()
    {
        _unitTestRuntimeProvider.TestIgnore("This scenario is ignored");
    }

    [Then("remaining minutes in oven should be 7 when actual minutes is 33")]
    public void WhenIHaveAPendingStep()
    {
        //_scenarioContext.Pending();
        throw new PendingStepException("This scenario is pending");
    }
}
