﻿using Rest.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ReverseWordsController : ControllerBase
    {
       
        private readonly IReverseWordsService _reverseWordsService;
        
        public ReverseWordsController(IReverseWordsService reverseWordsService)
        {
            _reverseWordsService = reverseWordsService;
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <example>
        /// { "value": "Diego Torres" }
        /// </example>
        /// <response code="200">Word(s) was/were reversed OK</response>
        /// <param name="sentence">A sentence</param>
        [ProducesResponseType(typeof(String), 200)]
        [HttpGet]
        public Task<String> Get([FromQuery] String sentence)
        {
            String result =_reverseWordsService.ReverseWords(sentence);
            return Task.FromResult(result);
        }
    }
}
