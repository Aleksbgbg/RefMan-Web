namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    public class AttributeExtractionStrategy : INodeContentExtractionStrategy
    {
        private readonly string _attributeName;

        public AttributeExtractionStrategy(string attributeName)
        {
            _attributeName = attributeName;
        }

        public string SelectContent(INode node)
        {
            return node.SelectAttributeValue(_attributeName);
        }
    }
}