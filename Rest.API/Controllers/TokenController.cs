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
    public class TokenController
    {

        [ProducesResponseType(200)]
        public Task<Guid> Get()
        {
            return Task.FromResult(new Guid("cbfca5cf-f16f-435b-bd09-a1963ee7cbe7"));
        }
        
        
    }
}