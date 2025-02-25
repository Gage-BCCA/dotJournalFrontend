using System.Text.Json.Serialization;

namespace CodeJournal.Entities.Responses;

public class IndividualProjectResponse
{
    [JsonPropertyName("status")]
    public String? Status { get; set; }
    
    [JsonPropertyName("project")]
    public Project? Project { get; set; }
}