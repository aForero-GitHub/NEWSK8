namespace NEWSK8.Commont.Models
{
    using Newtonsoft.Json;
    using System;

    public class Posts
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("idUser")]
        public string IdUser { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("data")]
        public DateTimeOffset Data { get; set; }

        [JsonProperty("users")]
        public Users Users { get; set; }

        [JsonProperty("imageFullPath")]
        public Uri ImageFullPath { get; set; }
    }
}
