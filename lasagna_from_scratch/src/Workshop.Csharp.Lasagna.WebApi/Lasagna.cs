namespace Workshop.Csharp.Lasagna.WebApi;

public class Lasagna
{
    public int ExpectedMinutesInOven() => 40;
    public int RemainingMinutesInOven(int actualMinutes) => ExpectedMinutesInOven() - actualMinutes;
    public int PreparationTimeInMinutes(int addedLayers) => 2 * addedLayers;
    public int ElapsedTimeInMinutes(int addedLayers, int minutesInOven) => PreparationTimeInMinutes(addedLayers) + minutesInOven;
}
