namespace RefMan.Services.Referencing.PageSearching
{
    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    public class PageSearcher : IPageSearcher
    {
        private readonly IWebpageReader _webpageReader;

        private readonly PageSearch _webpageTitleSearch;

        private readonly PageSearch _websiteNameSearch;

        private readonly PageSearch _websiteIconUrlSearch;

        public PageSearcher(IWebpageReader webpageReader, IContentExtractionStrategyFactory contentExtractionStrategyFactory)
        {
            _webpageReader = webpageReader;

            INodeContentExtractionStrategy extractContentAttribute =
                    contentExtractionStrategyFactory.ExtractAttributeByName("content");
            INodeContentExtractionStrategy extractInnerText =
                    contentExtractionStrategyFactory.ExtractInnerText();

            _webpageTitleSearch = PageSearch.NewBuilder()
                                            .AddSearchCriteria("/html/head/meta[@property='og:title']", extractContentAttribute)
                                            .AddSearchCriteria("/html/head/meta[@name='twitter:title']", extractContentAttribute)
                                            .AddSearchCriteria("/html/head/title", extractInnerText)
                                            .SetDefault("Untitled")
                                            .Build();

            _websiteNameSearch = PageSearch.NewBuilder()
                                           .AddSearchCriteria("/html/head/meta[@property='og:site_name']", extractContentAttribute)
                                           .SetDefault(null)
                                           .Build();

            INodeContentExtractionStrategy extractHrefAttribute =
                    contentExtractionStrategyFactory.ExtractAttributeByName("href");

            _websiteIconUrlSearch = PageSearch.NewBuilder()
                                              .AddSearchCriteria("/html/head/link[@rel='icon']", extractHrefAttribute)
                                              .AddSearchCriteria("/html/head/link[@rel='shortcut icon']", extractHrefAttribute)
                                              .SetDefault("/favicon.ico")
                                              .Build();
        }

        public string FindWebpageTitle()
        {
            return _webpageReader.FindPageElementValue(_webpageTitleSearch);
        }

        public string FindWebsiteName()
        {
            return _webpageReader.FindPageElementValue(_websiteNameSearch);
        }

        public string FindWebsiteIconUrl()
        {
            return _webpageReader.FindPageElementValue(_websiteIconUrlSearch);
        }
    }
}