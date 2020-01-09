namespace RefMan.Services.Referencing.PageSearching
{
    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    public class ContentSearchCriteria
    {
        public ContentSearchCriteria(string xPathExpression, INodeContentExtractionStrategy contentExtractionStrategy)
        {
            XPathExpression = xPathExpression;
            ContentExtractionStrategy = contentExtractionStrategy;
        }

        public string XPathExpression { get; }

        public INodeContentExtractionStrategy ContentExtractionStrategy { get; }
    }
}