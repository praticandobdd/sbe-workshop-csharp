using Xunit;
using Exercism.Tests;

namespace Workshop.Csharp.Lasagna.Specs.Lasagna;
public class LasagnaUnitTests
{
    [Fact]
    [Task(1)]
    public void Expected_minutes_in_oven()
    {
        Assert.Equal(40, Lasagna().ExpectedMinutesInOven());
    }

    [Fact]
    [Task(2)]
    public void Remaining_minutes_in_oven_after_twenty_five_minutes()
    {
        Assert.Equal(15, Lasagna().RemainingMinutesInOven(25));
    }

    [Fact]
    [Task(2)]
    public void Remaining_minutes_in_oven_after_thirty_three_minutes()
    {
        Assert.Equal(7, Lasagna().RemainingMinutesInOven(33));
    }

    [Fact]
    [Task(3)]
    public void Preparation_time_in_minutes_for_one_layer()
    {
        Assert.Equal(2, Lasagna().PreparationTimeInMinutes(1));
    }

    [Fact]
    [Task(3)]
    public void Preparation_time_in_minutes_for_multiple_layers()
    {
        Assert.Equal(8, Lasagna().PreparationTimeInMinutes(4));
    }

    [Fact]
    [Task(4)]
    public void Elapsed_time_in_minutes_for_one_layer()
    {
        Assert.Equal(32, Lasagna().ElapsedTimeInMinutes(1, 30));
    }

    [Fact]
    [Task(4)]
    public void Elapsed_time_in_minutes_for_multiple_layers()
    {
        Assert.Equal(16, Lasagna().ElapsedTimeInMinutes(4, 8));
    }

    static WebApi.Lasagna Lasagna() => new();

}
