using System.Text.Json.Serialization;

namespace CodeJournal.Entities.Responses;

public class MultiplePostResponse
{
    [JsonPropertyName("status")]
    public String? Status { get; set; }
    
    [JsonPropertyName("postSummaries")]
    public List<PostSummary>? PostList { get; set; }
}