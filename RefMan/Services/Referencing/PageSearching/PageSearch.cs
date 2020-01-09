namespace RefMan.Services.Referencing.PageSearching
{
    using System.Collections.Generic;

    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    public class PageSearch
    {
        private PageSearch(ContentSearchCriteria[] contentSearchCriteria, string defaultIfNotFound)
        {
            ContentSearchCriteria = contentSearchCriteria;
            DefaultIfNotFound = defaultIfNotFound;
        }

        public ContentSearchCriteria[] ContentSearchCriteria { get; }

        public string DefaultIfNotFound { get; }

        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public class Builder
        {
            private readonly List<ContentSearchCriteria> _contentSearchCriteria = new List<ContentSearchCriteria>();

            private string _defaultIfNotFound;

            public Builder AddSearchCriteria(string xPathExpression, INodeContentExtractionStrategy contentExtractionStrategy)
            {
                _contentSearchCriteria.Add(new ContentSearchCriteria(xPathExpression, contentExtractionStrategy));
                return this;
            }

            public Builder SetDefault(string defaultIfNotFound)
            {
                _defaultIfNotFound = defaultIfNotFound;
                return this;
            }

            public PageSearch Build()
            {
                return new PageSearch(_contentSearchCriteria.ToArray(), _defaultIfNotFound);
            }
        }
    }
}