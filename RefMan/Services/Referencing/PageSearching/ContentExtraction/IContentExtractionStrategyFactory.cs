namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    public interface IContentExtractionStrategyFactory
    {
        INodeContentExtractionStrategy ExtractAttributeByName(string attributeName);

        INodeContentExtractionStrategy ExtractInnerText();
    }
}