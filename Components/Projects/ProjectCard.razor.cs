using CodeJournal.Entities;
using Microsoft.AspNetCore.Components;

namespace CodeJournal.Components.Projects;

public partial class ProjectCard : ComponentBase
{
    [Parameter] public ProjectSummary ProjectSummary { get; set; } =  new ProjectSummary();
    
}