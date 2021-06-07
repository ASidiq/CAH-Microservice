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
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("")]
        public async Task<IActionResult> GetAnswer()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var task = client.GetStreamAsync("http://127.0.0.1:5000/answer/foodpack/");
            var answer = await JsonSerializer.DeserializeAsync<Answer>(await task);
            Console.WriteLine($"task:{{ { answer.Text} }}, pack: {{ {answer.Pack} }}");
            return Ok(answer);
        }
    }
}
