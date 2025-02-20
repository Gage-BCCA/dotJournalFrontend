using Microsoft.AspNetCore.Components;

namespace CodeJournal.Pages.Posts;

public partial class PostDetails : ComponentBase
{
    [Parameter] public int PostId { get; set; }
}