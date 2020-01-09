namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    public interface INodeContentExtractionStrategy
    {
        string SelectContent(INode node);
    }
}