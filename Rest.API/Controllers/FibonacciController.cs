using Rest.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FibonacciController
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
        [HttpGet]
        public Task<Int64> Get([FromQuery][Required] int n)
        {
            if(n>9999){
                return Task.FromResult((long)-1);    
            }
            return Task.FromResult(_fibonacciService.Fibonacci(n));
        }
        
        
    }
}