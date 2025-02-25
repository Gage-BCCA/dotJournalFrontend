using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using CodeJournal.Entities;
using CodeJournal.Entities.Responses;

namespace CodeJournal.Components.Projects;

public partial class ProjectList : ComponentBase
{
    [Inject] HttpClient HttpClient { get; set; }

    private MultipleProjectResponse? _multipleProjectResponse;
    private IEnumerable<ProjectSummary> _projectSummaries = [];

    private bool _isLoading = true;
    private bool _getProjectError;
    private bool _shouldRender;
    
    protected override bool ShouldRender() => _shouldRender;

    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://j-api.failedalgorithm.com/projects");

        try
        {
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                _multipleProjectResponse = await JsonSerializer.DeserializeAsync
                    <MultipleProjectResponse>(responseStream);

                if (_multipleProjectResponse != null)
                {
                    if (_multipleProjectResponse.Status != "success" || _multipleProjectResponse.Projects == null)
                    {
                        _getProjectError = true;
                    }
                    else
                    {
                        _projectSummaries = _multipleProjectResponse.Projects;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            _getProjectError = true;
        }
        
        _isLoading = false;
        _shouldRender = true;
    }

}