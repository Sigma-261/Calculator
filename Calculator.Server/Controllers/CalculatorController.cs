using Calculator.Server.Entities;
using CodingSeb.ExpressionEvaluator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Calculator.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController: ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private ApplicationContext _context;
    public CalculatorController(ILogger<CalculatorController> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }
    [Authorize]
    [HttpPost("/calculate")]
    public IActionResult Calculate(string math)
    {
        ExpressionEvaluator evaluator = new ExpressionEvaluator();
        var result = "";
        try
        {
            result = evaluator.Evaluate(math).ToString();
        }
        catch (Exception ex)
        {
            result = ex.Message;
            _logger.LogError(result);
        }

        MathCalculation mathCalculation = new MathCalculation()
        {
            DateTime = DateTime.UtcNow,
            Math = math,
            Result = result
        };


        _context.MathCalculations.Add(mathCalculation);
        _context.SaveChanges();


        return Ok(result);
    }
}
