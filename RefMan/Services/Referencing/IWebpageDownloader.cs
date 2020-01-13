namespace RefMan.Services.Referencing
{
    using System.Threading.Tasks;

    using RefMan.Services.Referencing.PageSearching;

    public interface IWebpageDownloader
    {
        Task<IWebpage> DownloadWebpageFromUrl(string url);
    }
}