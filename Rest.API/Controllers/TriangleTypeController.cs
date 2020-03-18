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
    public class TriangleTypeController
    {
        private readonly ITriangleTypeService _triangleTypeService;
        
        public TriangleTypeController(ITriangleTypeService triangleTypeService)
        {
            _triangleTypeService = triangleTypeService;
        }

        /// <summary>
        /// Returns the type of triangle given the lengths of its sides
        /// </summary>
        /// <example>
        /// { "a": 9 }
        /// { "b": 9 }
        /// { "c": 8 }
        /// </example>
        /// <response code="200">Triangle type was selected OK</response>
        /// <param name="a">The length of side a</param>
        /// <param name="b">The length of side b</param>
        /// <param name="c">The length of side c</param>
        [ProducesResponseType(typeof(String), 200)]
        [HttpGet]
        public Task<String> Get([FromQuery][Required]int a, [FromQuery][Required]int b, [FromQuery][Required]int c)
        {
            if(a==0 && b ==0 && c==0){
                return Task.FromResult("Size is not valid");
            }
            return Task.FromResult(_triangleTypeService.TrianlgeType(a, b, c));
        }
    }
}