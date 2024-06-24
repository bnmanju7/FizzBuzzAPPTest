using Microsoft.AspNetCore.Mvc;
using FizzBuzz.Services.Interfaces;


namespace FizzBuzzApp.Controllers
{
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzz _fizzBuzz;
        public FizzBuzzController(IFizzBuzz fizzBuzz) 
        { 
            _fizzBuzz = fizzBuzz;
        }
        [HttpGet("GetResult")]
        public async Task<IActionResult> GetResult(string? number)
        {
           try
            {
                return Ok(await _fizzBuzz.GetFizzBuzz(number));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
