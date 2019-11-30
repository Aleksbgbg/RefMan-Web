namespace RefMan.Models
{
    using System.Collections.Generic;

    using System.Text.Json.Serialization;

    public class Folder : FileSystemEntryBase
    {
        [JsonIgnore]
        public ICollection<Folder> Folders { get; set; }

        [JsonIgnore]
        public ICollection<File> Files { get; set; }
    }
}