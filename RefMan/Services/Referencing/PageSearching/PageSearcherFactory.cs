namespace RefMan.Services.Referencing.PageSearching
{
    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    public class PageSearcherFactory : IPageSearcherFactory
    {
        private readonly IContentExtractionStrategyFactory _contentExtractionStrategyFactory;

        public PageSearcherFactory(IContentExtractionStrategyFactory contentExtractionStrategyFactory)
        {
            _contentExtractionStrategyFactory = contentExtractionStrategyFactory;
        }

        public IPageSearcher CreatePageSearcherForWebpage(IWebpage webpage)
        {
            return new PageSearcher(new WebpageReader(webpage), _contentExtractionStrategyFactory);
        }
    }
}