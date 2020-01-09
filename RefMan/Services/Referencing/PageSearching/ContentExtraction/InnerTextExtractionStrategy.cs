namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    public class InnerTextExtractionStrategy : INodeContentExtractionStrategy
    {
        public string SelectContent(INode node)
        {
            return node.SelectInnerText();
        }
    }
}