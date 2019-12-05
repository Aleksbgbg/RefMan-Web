namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations;

    public class EntryCreation
    {
        public long ParentId => long.Parse(ParentIdString);

        public string ParentIdString { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }
    }
}