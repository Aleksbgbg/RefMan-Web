namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RefMan.Models.User;

    public class FileSystemEntryBase
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [ForeignKey(nameof(Parent))]
        public long? ParentId { get; set; }

        public Folder Parent { get; set; }

        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }

        public AppUser Owner { get; set; }
    }
}