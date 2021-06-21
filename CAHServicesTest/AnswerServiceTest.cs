using AnswerService.Model;
using RichardSzalay.MockHttp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using System.Net.Http;
using AnswerService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CAHServicesTest
{
    public class AnswerServiceTest
    {
        private AnswerController answerController;

        [Fact]
        public async void GetAnswerTest()
        {
            //Arrange
            Answer aAnswer = new Answer() { Text = "Abu", Pack = 33 };
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://localhost:5000/answer/foodpack/").Respond("application/json", JsonSerializer.Serialize<Answer>(aAnswer));
            var client = new HttpClient(mockHttp);
            AnswerController.client = client;
            answerController = new AnswerController();
            Type a = typeof(Answer);

            //Setting env variable
            Environment.SetEnvironmentVariable("answerApiUrl", "http://localhost:5000/answer/foodpack/");

            //Act
            var response = await answerController.GetAnswer();
            var result = (Answer)((OkObjectResult)response).Value;



            //Assert
            Assert.Equal(aAnswer.Text, result.Text);
            Assert.Equal(aAnswer.Pack, result.Pack);
            Assert.NotNull(result);
            Assert.IsType(a, result);


        }
    }
}
