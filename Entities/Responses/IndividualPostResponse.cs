using System.Text.Json.Serialization;

namespace CodeJournal.Entities.Responses;

public class IndividualPostResponse
{
    [JsonPropertyName("status")]
    public String? Status { get; set; }
    
    [JsonPropertyName("post")]
    public Post? Post { get; set; }
}