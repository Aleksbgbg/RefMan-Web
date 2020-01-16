namespace RefMan.Models.Referencing
{
    public class DocumentResult
    {
        public DocumentResult(Document document)
        {
            Id = document.Id;
        }

        public long Id { get; }
    }
}