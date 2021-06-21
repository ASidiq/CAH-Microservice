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
using MergedService.Controllers;
using Microsoft.AspNetCore.Mvc;
using MergedService.Model;


namespace CAHServicesTest
{
    public class MergeServiceTest
    {
        private MergeController mergeController;


        [Fact]
        public async void GetCard()
        {
            //Arrange
            Question aQuestion = new Question() { Text = "I am_.", Pack = 33, Pick = 1 };
            Answer aAnswer = new Answer() { Text = "Abu", Pack = 33 };
            
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When("http://localhost:44333/api/Question").Respond("application/json", JsonSerializer.Serialize<Question>(aQuestion));
            mockHttp.When("http://localhost:44337/api/Answer").Respond("application/json", JsonSerializer.Serialize<Answer>(aAnswer));

            var client = new HttpClient(mockHttp);
            MergeController.client = client;
            mergeController = new MergeController();


            //Setting env variable
            Environment.SetEnvironmentVariable("questionService", "http://localhost:44333/api/Question");
            Environment.SetEnvironmentVariable("answerService", "http://localhost:44337/api/Answer");

            //Act
            var response = await mergeController.GetCard();
            var result = ((OkObjectResult)response).Value;


            //Assert
            Assert.NotNull(result);


        }
    }

}
