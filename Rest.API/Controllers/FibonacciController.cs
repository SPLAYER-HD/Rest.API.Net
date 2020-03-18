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
            Console.WriteLine("FibonacciController");
            Console.WriteLine("n "+ n);
            bool isNegative = false;
            if(n<0){
                n = n * -1;
                isNegative = true;
            }
            Console.WriteLine("n after"+ n);
            if(n>9999){
                Console.WriteLine("if 0 ");
                return Task.FromResult((long)0);    
            }
            Int64 result =_fibonacciService.Fibonacci(n);
            if(isNegative){
                result = result * -1;
            }
            Console.WriteLine("result "+ result);
            return Task.FromResult(result);
        }
        
        
    }
}