namespace RefMan.Models.Referencing
{
    public class ReferenceResult : ReferenceBase
    {
        public ReferenceResult(Reference reference)
        {
            Id = reference.Id;
            AccessDate = reference.AccessDate;
            PublishYear = reference.PublishYear;
            Url = reference.Url;
            IconUrl = reference.IconUrl;
            WebpageTitle = reference.WebpageTitle;
            WebsiteName = reference.WebsiteName;
        }

        public string IdString => Id.ToString();
    }
}