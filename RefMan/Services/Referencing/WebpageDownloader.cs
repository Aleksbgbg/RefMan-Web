namespace RefMan.Services.Referencing
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using RefMan.Services.Referencing.PageSearching;

    public class WebpageDownloader : IWebpageDownloader
    {
        public async Task<IWebpage> DownloadWebpageFromUrl(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string webpageHtml = await httpClient.GetStringAsync(url);
                return Webpage.FromHtml(webpageHtml);
            }
        }
    }
}