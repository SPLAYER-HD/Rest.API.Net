using Rest.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TokenController
    {

        /// <summary>
        /// My token.
        /// </summary>
        /// <response code="200">token was returned</response>
        [ProducesResponseType(typeof(Guid), 200)]
        [HttpGet]
        public Task<Guid> Get()
        {
            return Task.FromResult(new Guid("cbfca5cf-f16f-435b-bd09-a1963ee7cbe7"));
        }
        
        
    }
}