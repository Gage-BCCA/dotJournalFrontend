using Microsoft.AspNetCore.Components;
using CodeJournal.Entities;

namespace CodeJournal.Components.Posts;

public partial class PostCard : ComponentBase
{
    [Parameter] public PostSummary Post { get; set; }
    [CascadingParameter(Name="IsCompact")] private bool IsCompact { get; set; }
}