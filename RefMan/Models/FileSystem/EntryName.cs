namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations;

    public class EntryName
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}