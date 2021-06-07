using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AnswerService.Model
{
    public class Answer
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("pack")]
        public int Pack { get; set; }
    }
}
