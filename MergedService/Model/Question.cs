using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json.Serialization;

namespace MergedService.Model
{
    public class Question
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("pick")]
        public int Pick { get; set; }

        [JsonPropertyName("pack")]
        public int Pack { get; set; }
    }
}
