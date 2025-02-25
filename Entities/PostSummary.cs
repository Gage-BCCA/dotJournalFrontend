using System.Text.Json.Serialization;
namespace CodeJournal.Entities;

public class PostSummary
{

    [JsonPropertyName("id")]
    public int PostId { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("blurb")]
    public string Blurb { get; set; }
    
    
    [JsonPropertyName("dateCreated")]
    public DateTime DateCreated { get; set; }
    
    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }
    
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new List<string>();

    
}  
