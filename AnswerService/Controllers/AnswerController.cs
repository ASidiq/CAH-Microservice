using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using AnswerService.Model;
using Microsoft.Extensions.Configuration;

namespace AnswerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        // Static Instance of HttpClient handles requests and responses
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration Configuration;

        public AnswerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAnswer()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //answerApiUrl can be found in the appsettings.json file
            var task = client.GetStreamAsync(Configuration["answerApiUrl"]);
            var answer = await JsonSerializer.DeserializeAsync<Answer>(await task);

            return Ok(answer);
        }
    }
}
