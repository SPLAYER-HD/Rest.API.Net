using Rest.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TriangleTypeController
    {
        private readonly ITriangleTypeService _triangleTypeService;
        
        public TriangleTypeController(ITriangleTypeService triangleTypeService)
        {
            _triangleTypeService = triangleTypeService;
        }

        [ProducesResponseType(200)]
        public Task<String> Get(int a, int b, int c)
        {
            if(a==0 && b ==0 && c==0){
                return Task.FromResult("Size is not valid");
            }
            return Task.FromResult(_triangleTypeService.TrianlgeType(a, b, c));
        }
    }
}