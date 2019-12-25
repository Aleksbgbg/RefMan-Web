namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations.Schema;

    using RefMan.Models.Referencing;

    public class File : Node
    {
        [ForeignKey(nameof(Document))]
        public long DocumentId { get; set; }

        public Document Document { get; set; }
    }
}