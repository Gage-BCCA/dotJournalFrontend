using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;


namespace CodeJournal.Components.Posts;

public partial class PostList : ComponentBase
{
    [Inject]
    HttpClient Client { get; set; }

    private IEnumerable<Project>? _projects = [];
    private bool _shouldRender;
    private bool _getProjectsError;
    
    [Parameter]
    public string PostListTitle { get; set; }

    protected override bool ShouldRender() => _shouldRender;
    
    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:5099/projects");

        try
        {
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                _projects = await JsonSerializer.DeserializeAsync
                    <IEnumerable<Project>>(responseStream);
            }
            else
            {
                _getProjectsError = true;
            }
        }
        catch (Exception e)
        {
            _getProjectsError = true;
        }

        _shouldRender = true;

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