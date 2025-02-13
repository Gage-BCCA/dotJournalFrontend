using System.Text.Json.Serialization;

namespace CodeJournal.Entities;

public class Project
{
        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
}