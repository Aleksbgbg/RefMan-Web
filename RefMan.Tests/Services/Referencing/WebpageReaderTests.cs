namespace RefMan.Tests.Services.Referencing
{
    using RefMan.Services.Referencing.PageSearching;
    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    using Xunit;

    public class WebpageReaderTests
    {
        private readonly PageSearch _webpageTitleSearch;

        public WebpageReaderTests()
        {
            ContentExtractionStrategyFactory contentExtractionStrategyFactory = new ContentExtractionStrategyFactory();

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
        }

        [Fact]
        public void NoHtml_ReturnsUntitled()
        {
            Webpage webpage = Webpage.FromHtml("");

            string title = FindWebpageTitle(webpage);

            Assert.Equal("Untitled", title);
        }

        [Fact]
        public void FindsWebpageTitle_FromTitleTag()
        {
            Webpage webpage = Webpage.FromHtml(@"
<html>
    <head>
        <title>Page Title - Website Name</title>
    </head>
</html>
");

            string title = FindWebpageTitle(webpage);

            Assert.Equal("Page Title - Website Name", title);
        }

        [Fact]
        public void FindsWebpageTitle_FromTwitterTitleTag_EvenWhenTitlePresent()
        {
            Webpage webpage = Webpage.FromHtml(@"
<html>
    <head>
        <title>Page Title - Website Name</title>
        <meta name='twitter:title' content='Twitter Title'>
    </head>
</html>
");

            string title = FindWebpageTitle(webpage);

            Assert.Equal("Twitter Title", title);
        }

        [Fact]
        public void FindsWebpageTitle_FromOgTitleTag_EvenWhenTwitterTitlePresent()
        {
            Webpage webpage = Webpage.FromHtml(@"
<html>
    <head>
        <title>Page Title - Website Name</title>
        <meta name='twitter:title' content='Twitter Title'>
        <meta property='og:title' content='Og Title'>
    </head>
</html>
");

            string title = FindWebpageTitle(webpage);

            Assert.Equal("Og Title", title);
        }

        private static PageSearcher CreatePageSearcher(IWebpage webpage)
        {
            return new PageSearcher(new WebpageReader(webpage), new ContentExtractionStrategyFactory());
        }

        private string FindWebpageTitle(IWebpage webpage)
        {
            return new WebpageReader(webpage).FindPageElementValue(_webpageTitleSearch);
        }
    }
}