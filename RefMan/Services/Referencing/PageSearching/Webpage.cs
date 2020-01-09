namespace RefMan.Services.Referencing.PageSearching
{
    using HtmlAgilityPack;

    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    public class Webpage : IWebpage
    {
        private readonly HtmlDocument _htmlDocument;

        private Webpage(HtmlDocument htmlDocument)
        {
            _htmlDocument = htmlDocument;
        }

        public static Webpage FromHtml(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            return new Webpage(document);
        }

        public PageElement SearchByCriteria(ContentSearchCriteria contentSearchCriteria)
        {
            HtmlNode node = _htmlDocument.DocumentNode.SelectSingleNode(contentSearchCriteria.XPathExpression);

            if (node == null)
            {
                return PageElement.NonExistent;
            }

            INodeContentExtractionStrategy contentExtractionStrategy = contentSearchCriteria.ContentExtractionStrategy;
            string searchResult = contentExtractionStrategy.SelectContent(new Node(node));

            return new PageElement(searchResult);
        }
    }
}