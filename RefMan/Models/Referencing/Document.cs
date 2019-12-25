namespace RefMan.Models.Referencing
{
    using System.Collections.Generic;

    using RefMan.Models.FileSystem;

    public class Document
    {
        public long Id { get; set; }

        public File File { get; set; }

        public ICollection<Reference> References { get; set; }
    }
}