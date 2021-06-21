using QuestionService.Model;
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
using QuestionService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CAHServicesTest
{
    public class QuestionServiceTest
    {
        private QuestionController questionController;

        [Fact]
        public async void GetQuestionTest()
        {
            //Arrange
            Question aQuestion = new Question() { Text = "I am_.", Pack = 33, Pick = 1 };
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://localhost:5000/question/foodpack/").Respond("application/json", JsonSerializer.Serialize<Question>(aQuestion));
            var client = new HttpClient(mockHttp);
            QuestionController.client = client;
            questionController = new QuestionController();
            Type q = typeof(Question);

            //Setting env variable
            Environment.SetEnvironmentVariable("questionApiUrl", "http://localhost:5000/question/foodpack/");

            //Act
            var response = await questionController.GetQuestion();
            var result = (Question)((OkObjectResult)response).Value;



            //Assert
            Assert.Equal(aQuestion.Text, result.Text);
            Assert.Equal(aQuestion.Pack, result.Pack);
            Assert.Equal(aQuestion.Pick, result.Pick);
            Assert.NotNull(result);
            Assert.IsType(q, result);
                

        }
    }
}
