using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using QuestionService.Model;

namespace QuestionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        // Static Instance of HttpClient handles requests and responses
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("")]
        public async Task<IActionResult> GetQuestion()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var task = client.GetStreamAsync("http://127.0.0.1:5000/question/foodpack/");
            var question = await JsonSerializer.DeserializeAsync<Question>(await task);
            Console.WriteLine($"task:{{ { question.Text} }}, pick:{{ {question.Pick} }}, pack: {{ {question.Pack} }}");
            return Ok(question);
        }


    }
}
