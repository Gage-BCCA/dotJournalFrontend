using Microsoft.AspNetCore.Components;
using CodeJournal.Entities;

namespace CodeJournal.Components.Posts;

public partial class PostCard : ComponentBase
{
    [Parameter]
    public Post Post { get; set; }
}