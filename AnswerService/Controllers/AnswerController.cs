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

namespace AnswerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        // Static Instance of HttpClient handles requests and responses
        public static HttpClient client = new HttpClient();

        public AnswerController()
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAnswer()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //answerApiUrl can be found in properties -> launchsettings and can be dynamically set in the dockerfile
            var task = client.GetStreamAsync(Environment.GetEnvironmentVariable("answerApiUrl"));
            var answer = await JsonSerializer.DeserializeAsync<Answer>(await task);

            return Ok(answer);
        }
    }
}
