using CodeJournal.Entities;
using CodeJournal.Entities.Responses;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace CodeJournal.Components.Projects.IndividualProject;

public partial class IndividualProject : ComponentBase
{
    [Parameter] public int ProjectId { get; set; }
    
     [Inject] HttpClient Client { get; set; }
    
        [Parameter] public int PostId { get; set; }

        private IndividualProjectResponse? _individualProjectResponse = new IndividualProjectResponse();
        private Project _project = new Project();

        private bool _shouldRender;
        private bool _getProjectError;
        private bool _isLoading = true;
    
        protected override bool ShouldRender() => _shouldRender;
    
        protected override async Task OnInitializedAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://j-api.failedalgorithm.com/projects/{ProjectId}");

            try
            {
                var response = await Client.SendAsync(request);
                
                if (response.IsSuccessStatusCode)
                {
                    await using var responseStream = await response.Content.ReadAsStreamAsync();
                    _individualProjectResponse = await JsonSerializer.DeserializeAsync
                        <IndividualProjectResponse>(responseStream);
                    if (_individualProjectResponse != null)
                    {
                        if (_individualProjectResponse.Status != "success" || _individualProjectResponse.Project == null)
                        {
                            _getProjectError = true;
                        }
                        else
                        {
                            _project = _individualProjectResponse.Project;
                        }

                    }
                }
                else
                {
                    _getProjectError = true;
                }
                
                
                
            }
            catch (Exception e)
            {
                _getProjectError = true;
            }

            _isLoading = false;
            _shouldRender = true;

        }
}