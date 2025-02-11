using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;


namespace CodeJournal.Components.Posts;

public partial class PostList : ComponentBase
{
    [Inject]
    HttpClient Client { get; set; }

    private IEnumerable<Project>? projects = [];
    private bool shouldRender;
    private bool getProjectsError;

    protected override bool ShouldRender() => shouldRender;
    
    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:5099/projects");

        var response = await Client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            projects = await JsonSerializer.DeserializeAsync
                <IEnumerable<Project>>(responseStream);
        }
        else
        {
            getProjectsError = true;
        }

        shouldRender = true;

    }

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
}