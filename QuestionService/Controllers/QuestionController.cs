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
using Microsoft.Extensions.Configuration;

namespace QuestionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        // Static Instance of HttpClient handles requests and responses
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration Configuration;

        public QuestionController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetQuestion()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //questionApiUrl can be found in the appsettings.json file
            var task = client.GetStreamAsync(Configuration["questionApiUrl"]);
            var question = await JsonSerializer.DeserializeAsync<Question>(await task);
            return Ok(question);
        }


    }
}
