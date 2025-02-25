using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using CodeJournal.Entities;
using CodeJournal.Entities.Responses;


namespace CodeJournal.Components.Posts;

public partial class PostList : ComponentBase
{
    [Inject]
    HttpClient Client { get; set; }

    private IEnumerable<PostSummary>? _posts = [];
    private MultiplePostResponse _rawResponse;
    private bool _shouldRender;
    private bool _getPostsError;
    
    [Parameter] public string PostListTitle { get; set; }
    [Parameter] public bool IsCompact { get; set; } = true;
    [Parameter] public string ApiEndpoint { get; set; } = "all";

    protected override bool ShouldRender() => _shouldRender;
    
    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://j-api.failedalgorithm.com/posts/" + ApiEndpoint);

        try
        {
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                _rawResponse = await JsonSerializer.DeserializeAsync
                    <MultiplePostResponse>(responseStream);
                _posts = _rawResponse.PostList;
            }
            else
            {
                _getPostsError = true;
            }
            
            
        }
        catch (Exception e)
        {
            _getPostsError = true;
        }

        _shouldRender = true;

    }
}