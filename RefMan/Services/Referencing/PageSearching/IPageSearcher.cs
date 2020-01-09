namespace RefMan.Services.Referencing.PageSearching
{
    public interface IPageSearcher
    {
        string FindWebpageTitle();

        string FindWebsiteName();

        string FindWebsiteIconUrl();
    }
}