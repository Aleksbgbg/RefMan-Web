namespace RefMan.Services.Referencing.PageSearching.ContentExtraction
{
    public interface INode
    {
        string SelectAttributeValue(string attributeName);

        string SelectInnerText();
    }
}