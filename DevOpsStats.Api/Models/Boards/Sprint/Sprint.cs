﻿using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Boards.Sprint
{
    public class Sprint
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
        
        [JsonProperty("attributes")]
        public Attribute Attribute { get; set; }
    }
}
