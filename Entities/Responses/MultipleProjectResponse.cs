using System.Text.Json.Serialization;

namespace CodeJournal.Entities.Responses;

public class MultipleProjectResponse
{
    [JsonPropertyName("status")]
    public String? Status { get; set; }
    
    [JsonPropertyName("projects")]
    public List<ProjectSummary>? Projects { get; set; }
}