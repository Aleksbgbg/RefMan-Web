namespace RefMan.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FileSystemEntryBase
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [ForeignKey(nameof(Parent))]
        public long? ParentId { get; set; }

        public Folder Parent { get; set; }
    }
}