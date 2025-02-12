using CodeJournal.Entities;
using Microsoft.AspNetCore.Components;

namespace CodeJournal.Components.Titlebar
{
    public partial class NavMenu : ComponentBase
    {
        private List<DropdownLink> _postDropdownLinks = new List<DropdownLink>
        {
            new DropdownLink("All Posts", "posts/all/"),
            new DropdownLink("Tags", "posts/tags/all")
        };
    }  
}
