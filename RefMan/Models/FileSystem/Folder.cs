namespace RefMan.Models.FileSystem
{
    using System.Collections.Generic;

    public class Folder : Node
    {
        public ICollection<Folder> Folders { get; set; }

        public ICollection<File> Files { get; set; }
    }
}