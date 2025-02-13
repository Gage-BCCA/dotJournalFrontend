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

    private IEnumerable<Post>? _posts = [];
    private PostResponse _rawResponse;
    private bool _shouldRender;
    private bool _getPostsError;
    
    [Parameter]
    public string PostListTitle { get; set; }

    protected override bool ShouldRender() => _shouldRender;
    
    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:5099/posts");

        try
        {
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                _rawResponse = await JsonSerializer.DeserializeAsync
                    <PostResponse>(responseStream);
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