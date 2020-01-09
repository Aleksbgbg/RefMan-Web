namespace RefMan.Services.Referencing.PageSearching
{
    public interface IWebpage
    {
        PageElement SearchByCriteria(ContentSearchCriteria contentSearchCriteria);
    }
}