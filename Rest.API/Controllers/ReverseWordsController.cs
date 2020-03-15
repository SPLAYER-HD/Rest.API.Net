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
    public class ReverseWordsController : ControllerBase
    {
       
        private readonly IReverseWordsService _reverseWordsService;
        
        public ReverseWordsController(IReverseWordsService reverseWordsService)
        {
            _reverseWordsService = reverseWordsService;
        }

        [ProducesResponseType(200)]
        public Task<String> Get(String value)
        {
            return Task.FromResult(_reverseWordsService.ReverseWords(value));
        }
    }
}
