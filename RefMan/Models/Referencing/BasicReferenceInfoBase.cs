namespace RefMan.Models.Referencing
{
    using System;

    public abstract class BasicReferenceInfoBase
    {
        public DateTime AccessDate { get; set; }

        public int? PublishYear { get; set; }

        public string WebsiteName { get; set; }

        public string WebpageTitle { get; set; }
    }
}