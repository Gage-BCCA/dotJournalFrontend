using System.Text.Json.Serialization;

namespace CodeJournal.Entities;

public class Post
{
    [JsonPropertyName("id")]
    public int PostId { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("blurb")]
    public string Blurb { get; set; }
    
    [JsonPropertyName("content")]
    public string Content {get; set; }
    
    [JsonPropertyName("dateCreated")]
    public DateTime DateCreated { get; set; }
    
    [JsonPropertyName("dateModified")]
    public DateTime DateModified { get; set; }
    
    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }
    
    [JsonPropertyName("dislikeCount")]
    public int DislikeCount { get; set; }
    
    [JsonPropertyName("parentProjectId")]
    public int ParentProjectId { get; set; }
    
    [JsonPropertyName("parentProjectTitle")]
    public string ParentProjectTitle { get; set; }

    public void FormatContent()
    {
        Content = Content.Replace("\\n", "\r\n");;
    }
}