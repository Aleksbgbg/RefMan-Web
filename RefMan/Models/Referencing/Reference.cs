namespace RefMan.Models.Referencing
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reference
    {
        public long Id { get; set; }

        public DateTime AccessDate { get; set; }

        public int? PublishYear { get; set; }

        public string WebsiteName { get; set; }

        public string WebpageTitle { get; set; }

        public string Url { get; set; }

        public string IconUrl { get; set; }

        [ForeignKey(nameof(Document))]
        public long DocumentId { get; set; }

        public Document Document { get; set; }
    }
}