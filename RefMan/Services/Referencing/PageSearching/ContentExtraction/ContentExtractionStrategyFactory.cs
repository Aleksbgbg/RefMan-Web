namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    public class ContentExtractionStrategyFactory : IContentExtractionStrategyFactory
    {
        private static readonly InnerTextExtractionStrategy InnerTextExtractionStrategy = new InnerTextExtractionStrategy();

        public INodeContentExtractionStrategy ExtractAttributeByName(string attributeName)
        {
            return new AttributeExtractionStrategy(attributeName);
        }

        public INodeContentExtractionStrategy ExtractInnerText()
        {
            return InnerTextExtractionStrategy;
        }
    }
}