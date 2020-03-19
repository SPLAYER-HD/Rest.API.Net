using Rest.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class FibonacciController : ControllerBase
    {
        private readonly IFibonacciService _fibonacciService;
        
        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <example>
        /// { "n": "8" }
        /// </example>
        /// <response code="200">Fibonacci was processed OK</response>
        /// <param name="n">The index (n) of the fibonacci sequence</param>
        [ProducesResponseType(typeof(Int64), 200)]
        [ProducesResponseType(typeof(Int64), 400)]
        [HttpGet]
        public ActionResult<Int64> Get([FromQuery][Required] Int64 n)
        {
            if(n == 0){
                return Ok((long)0);
            }
            if(n>92 || n<-92){// it works until 9999 but to this example is restricted to 92
                return BadRequest("no content");
            }
            bool isNegative = false;
            if(n<0){
                n = n * -1;
                isNegative = true;
            }
            Int64 result =_fibonacciService.Fibonacci(n);
            if(isNegative && n%2==0){
                result = result * -1;
            }
            return Ok(result);
        }
        
        
    }
}