using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using MergedService.Model;

namespace MergedService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MergeController : ControllerBase
    {
        // Static Instance of HttpClient handles requests and responses
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("")]
        public async Task<IActionResult> GetCard()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Question
            var questionTask = client.GetStreamAsync("https://localhost:44333/api/Question");
            var question = await JsonSerializer.DeserializeAsync<Question>(await questionTask);

            //Answer
            var answerTask = client.GetStreamAsync("https://localhost:44337/api/Answer");
            var answer = await JsonSerializer.DeserializeAsync<Question>(await answerTask);

            string cah = question.Text.Replace("_", answer.Text.Replace(".", ""));

            var card = new { question, answer, cah};

            Console.WriteLine($"task:{{ { question.Text} }}, pick:{{ {question.Pick} }}, pack: {{ {question.Pack} }}");
            return Ok(card);
        }
    }
}
