using Microsoft.AspNetCore.Mvc;

namespace Workshop.Csharp.Lasagna.WebApi.Controllers;

[ApiController]
[Route("/api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly Calculator _calculator = new Calculator();

    [HttpGet("sum")]
    public async Task<ActionResult<int>> Sum(int number1, int number2) => Ok(await Task.FromResult(_calculator.Sum(number1, number2)));

}