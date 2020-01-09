namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    using HtmlAgilityPack;

    public class Node : INode
    {
        private readonly HtmlNode _htmlNode;

        public Node(HtmlNode htmlNode)
        {
            _htmlNode = htmlNode;
        }

        public string SelectAttributeValue(string attributeName)
        {
            return _htmlNode.Attributes[attributeName].Value;
        }

        public string SelectInnerText()
        {
            return _htmlNode.InnerText;
        }
    }
}