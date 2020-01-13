namespace RefMan.Services.Referencing.PageSearching
{
    public interface IPageSearcherFactory
    {
        IPageSearcher CreatePageSearcherForWebpage(IWebpage webpage);
    }
}