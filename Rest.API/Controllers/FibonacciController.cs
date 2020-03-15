using Rest.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FibonacciController
    {
        private readonly IFibonacciService _fibonacciService;
        
        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        //[SwaggerOperation(Summary="sss", Description="des") ]
        /// <summary>
        /// Unique identifier
        /// </summary>
        /// <example>
        /// { "id": "5cad7fa2-ac5d-46bb-a8ab-8d4d4df10f91" }
        /// </example>
        [ProducesResponseType(200)]
        public Task<Int64> Get([Required] int n)
        {
            if(n>9999){
                return Task.FromResult((long)-1);    
            }
            return Task.FromResult(_fibonacciService.Fibonacci(n));
        }
        
        
    }
}