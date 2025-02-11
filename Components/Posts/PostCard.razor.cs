using Microsoft.AspNetCore.Components;

namespace CodeJournal.Components.Posts;

public partial class PostCard : ComponentBase
{
    [Parameter]
    public string Title { get; set; }
   [Parameter]
    public string Language { get; set; }
}