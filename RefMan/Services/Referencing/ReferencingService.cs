namespace RefMan.Services.Referencing
{
    using System;
    using System.Threading.Tasks;

    using RefMan.Models.Referencing;
    using RefMan.Services.Referencing.PageSearching;

    public class ReferencingService : IReferencingService
    {
        private readonly IWebpageDownloader _webpageDownloader;

        private readonly IPageSearcherFactory _pageSearcherFactory;

        public ReferencingService(IWebpageDownloader webpageDownloader, IPageSearcherFactory pageSearcherFactory)
        {
            _webpageDownloader = webpageDownloader;
            _pageSearcherFactory = pageSearcherFactory;
        }

        public async Task<ReferenceProducedResult> ProduceReferenceForUrl(string url)
        {
            IWebpage webpage = await _webpageDownloader.DownloadWebpageFromUrl(url);

            IPageSearcher pageSearcher = _pageSearcherFactory.CreatePageSearcherForWebpage(webpage);

            return new ReferenceProducedResult
            {
                AccessDate = DateTime.Today,
                PublishYear = null,
                Url = url,
                IconUrl = EnsureUrlRootedTo(pageSearcher.FindWebsiteIconUrl(), url),
                WebpageTitle = pageSearcher.FindWebpageTitle(),
                WebsiteName = pageSearcher.FindWebsiteName() ?? new Uri(url).Authority
            };
        }

        private static string EnsureUrlRootedTo(string url, string rootUrl)
        {
            if (IsAbsoluteUrl(url))
            {
                return url;
            }

            Uri rootUri = new Uri(rootUrl);

            return $"{rootUri.Scheme}://{rootUri.Authority}{url}";
        }

        private static bool IsAbsoluteUrl(string url)
        {
            return !url.StartsWith('/');
        }
    }
}