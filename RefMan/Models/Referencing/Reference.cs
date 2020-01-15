namespace RefMan.Models.Referencing
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reference : ReferenceBase
    {
        [ForeignKey(nameof(Document))]
        public long DocumentId { get; set; }

        public Document Document { get; set; }
    }
}