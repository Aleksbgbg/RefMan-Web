namespace RefMan.Models.Referencing
{
    using System.Collections.Generic;
    using System.Linq;

    public class DocumentResult
    {
        public DocumentResult(Document document)
        {
            Id = document.Id;
            References = document.References.Select(reference => new ReferenceResult(reference));
        }

        public long Id { get; }

        public string IdString => Id.ToString();

        public IEnumerable<ReferenceResult> References { get; }
    }
}