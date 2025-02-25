namespace CodeJournal.Entities.ComponentModels
{
    public class DropdownLink
    {
        public string LinkText { get; set; } = "Menu Button";
        public string LinkUrl { get; set; } = "https://google.com";

        public DropdownLink(String text, String url)
        {
            LinkText = text;
            LinkUrl = url;
        }
    }
}

