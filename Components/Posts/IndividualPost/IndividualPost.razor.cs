using CodeJournal.Entities;
using CodeJournal.Entities.Responses;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace CodeJournal.Components.Posts.IndividualPost
{
    
    public partial class IndividualPost : ComponentBase
    {
        [Inject]
        HttpClient Client { get; set; }
    
        [Parameter]
        public int PostId { get; set; }

        private IndividualPostResponse? _individualPostResponse = new IndividualPostResponse();
        private Post _post = new Post();

        private bool _shouldRender;
        private bool _getPostError;
    
        protected override bool ShouldRender() => _shouldRender;
    
        protected override async Task OnInitializedAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://localhost:5099/posts/{PostId}");

            try
            {
                var response = await Client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    await using var responseStream = await response.Content.ReadAsStreamAsync();
                    _individualPostResponse = await JsonSerializer.DeserializeAsync
                        <IndividualPostResponse>(responseStream);
                    if (_individualPostResponse != null)
                    {
                        _post = _individualPostResponse.Post;
                    }
                    
                }
                else
                {
                    _getPostError = true;
                }
            
            
            }
            catch (Exception e)
            {
                _getPostError = true;
            }

            _shouldRender = true;

        }

        private string ToHtml(string html)
        {
            return string.IsNullOrEmpty(html) ? string.Empty : Markdig.Markdown.ToHtml(html);
        }
    }
}

