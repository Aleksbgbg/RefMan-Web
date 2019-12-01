namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class FileSystemEntryBase
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Parent))]
        public long? ParentId { get; set; }

        [JsonIgnore]
        public Folder Parent { get; set; }
    }
}