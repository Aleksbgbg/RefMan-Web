namespace RefMan.Services.Referencing.PageSearching
{
    public class WebpageReader : IWebpageReader
    {
        private readonly IWebpage _webpage;

        public WebpageReader(IWebpage webpage)
        {
            _webpage = webpage;
        }

        public string FindPageElementValue(PageSearch pageSearch)
        {
            foreach (ContentSearchCriteria contentSearchCriteria in pageSearch.ContentSearchCriteria)
            {
                PageElement pageElement = _webpage.SearchByCriteria(contentSearchCriteria);

                if (pageElement.Exists)
                {
                    return pageElement.Value;
                }
            }

            return pageSearch.DefaultIfNotFound;
        }
    }
}