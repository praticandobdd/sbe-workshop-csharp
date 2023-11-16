using Microsoft.AspNetCore.Mvc;

namespace Workshop.Csharp.Lasagna.WebApi.Controllers;

/// <summary>
/// Lasagna challenge from Exercism.com
/// </summary>
[ApiController]
[Route("/api/lasagna")]
public class LasagnaController : ControllerBase
{

/// <summary>
/// summary for endpoint /times/expected
/// </summary>
/// <returns></returns>
    [HttpGet("times/expected")]
    public async Task<ActionResult<string>> ExpectedMinutesInOven() => Ok(await Task.FromResult(new Lasagna().ExpectedMinutesInOven()));

/// <summary>
/// summary for endpoint /times/remaining
/// </summary>
/// <returns></returns>
    [HttpGet("times/remaining")]
    public async Task<ActionResult<string>> RemainingMinutesInOven(int actualMinutes) => Ok(await Task.FromResult(new Lasagna().RemainingMinutesInOven(actualMinutes)));    


/// <summary>
/// summary for endpoint /times/preparation
/// </summary>
/// <returns></returns>
    [HttpGet("times/preparation")]
    public async Task<ActionResult<string>> PreparationTimeInMinutes(int addedLayers) => Ok(await Task.FromResult(new Lasagna().PreparationTimeInMinutes(addedLayers)));    

/// <summary>
/// summary for endpoint /times/elapsed
/// </summary>
/// <returns></returns>
    [HttpGet("times/elapsed")]
    public async Task<ActionResult<string>> PreparationTimeInMinutes(int addedLayers, int minutesInOven) => Ok(await Task.FromResult(new Lasagna().ElapsedTimeInMinutes(addedLayers,minutesInOven)));    

}
