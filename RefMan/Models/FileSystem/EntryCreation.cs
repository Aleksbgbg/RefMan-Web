namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations;

    public class EntryCreation : EntryName
    {
        public long ParentId => ParentIdString == null ? 0 : long.Parse(ParentIdString);

        [Required]
        public string ParentIdString { get; set; }
    }
}