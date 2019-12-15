namespace RefMan.Models.FileSystem
{
    public class EntryCreation : EntryName
    {
        public long ParentId => long.Parse(ParentIdString);

        public string ParentIdString { get; set; }
    }
}