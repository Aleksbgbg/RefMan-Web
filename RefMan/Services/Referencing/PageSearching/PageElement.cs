namespace RefMan.Services.Referencing.PageSearching
{
    public class PageElement
    {
        public static PageElement NonExistent { get; } = new PageElement();

        public PageElement(string value)
        {
            Exists = true;
            Value = value;
        }

        private PageElement()
        {
            Exists = false;
        }

        public bool Exists { get; }

        public string Value { get; }
    }
}