using Microsoft.AspNetCore.Mvc;

namespace Workshop.Csharp.Lasagna.WebApi.Controllers;

[ApiController]
[Route("/api/lasagna")]
public class LasagnaController : ControllerBase
{
    [HttpGet("times/expected")]
    public async Task<ActionResult<string>> ExpectedMinutesInOven() => Ok(await Task.FromResult(new Lasagna().ExpectedMinutesInOven()));

}