using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Workshop.Csharp.Lasagna.Specs.Lasagna;

public class LasagnaWebApiTests
{
    private readonly HttpClient _client;

    public LasagnaWebApiTests()
    {
        var factory = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>();
        _client = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task ThenExpectedMinutesInOvenShouldBe()
    {
        var actualExpectedMinutes = await _client.GetStringAsync("/api/lasagna/times/expected");
        actualExpectedMinutes.Should().Be("40");
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public async Task ThenRemainingMinutesInOvenShouldBe(int expected, int actualMinutes)
    =>
        await ShouldBe($"/api/lasagna/times/remaining?actualMinutes={actualMinutes}", expected);
 
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public async Task ThenPreparationTimeInMinutesShouldBe(int expected, int addedLayers)
    =>
        await ShouldBe($"/api/lasagna/times/preparation?addedLayers={addedLayers}", expected);
    

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(2, 2, 2)]
    public async Task ThenElapsedTimeInMinutesShouldBe(
        int expected,
        int addedLayers,
        int minutesInOven
    )
     =>
       await ShouldBe($"/api/lasagna/times/elapsed?addedLayers={addedLayers}&minutesInOven={minutesInOven}", expected);

    internal async Task ShouldBe(string route, int expected)
    {
        var response = await _client.GetAsync(route);
        response.StatusCode.Should().Be(StatusCodes.Status200OK);
        var actual = await _client.GetStringAsync(route);
        actual.Should().Be(expected.ToString());
    }
}
