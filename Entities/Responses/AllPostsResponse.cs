using System.Text.Json.Serialization;

namespace CodeJournal.Entities.Responses;

public class PostResponse
{
    [JsonPropertyName("status")]
    public String? Status { get; set; }
    
    [JsonPropertyName("posts")]
    public List<Post>? PostList { get; set; }
}