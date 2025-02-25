using CodeJournal.Entities;
using CodeJournal.Entities.ComponentModels;
using Microsoft.AspNetCore.Components;

namespace CodeJournal.Components.Titlebar
{
    public partial class DropdownMenu : ComponentBase
    {
        [Parameter]
        public bool IsVisible { get; set; } = false;

        [Parameter]
        public string Title { get; set; } = "Dropdown Menu";
    
        [Parameter]
        public List<DropdownLink> Links { get; set; } = new List<DropdownLink>();

        private void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }
    } 
}

