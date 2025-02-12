using Microsoft.AspNetCore.Components;

namespace CodeJournal.Components.Titlebar
{
    public partial class DropdownItem : ComponentBase
    {
        [Parameter] public string Text { get; set; } = "PlaceHolder";
    
        [Parameter] public string Url { get; set; } = "https://Google.com";
    } 
}

