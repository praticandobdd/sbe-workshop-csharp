using Microsoft.AspNetCore.Mvc;

namespace Workshop.Csharp.Lasagna.WebApi.Controllers;

[ApiController]
[Route("/api/lasagna")]
public class LasagnaController : ControllerBase
{
    [HttpGet("times/expected")]
    public async Task<ActionResult<string>> ExpectedMinutesInOven() 
    => Ok(await Task.FromResult(
    new Lasagna().ExpectedMinutesInOven()
    ));

    [HttpGet("times/remaining")]
    public async Task<ActionResult<string>> ExpectedMinutesInOven(int actualMinutes) 
    => Ok(await Task.FromResult(
    new Lasagna().RemainingMinutesInOven(actualMinutes)
    ));

    [HttpGet("times/elapsed")]
    public async Task<ActionResult<string>> ExpectedMinutesInOven(int addedLayers, int minutesInOven) 
    => Ok(await Task.FromResult(
    new Lasagna().ElapsedTimeInMinutes(addedLayers,minutesInOven)
    ));

    [HttpGet("times/preparation")]
    public async Task<ActionResult<string>> PreparationTimeInMinutes(int addedLayers) 
    => Ok(await Task.FromResult(
    new Lasagna().PreparationTimeInMinutes(addedLayers)
    ));

}