namespace RefMan.Models.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RefMan.Models.Referencing;

    public interface IDocumentRepository
    {
        bool DocumentExists(long documentId);

        bool UserOwnsDocument(long documentId, long ownerId);

        bool ReferenceExistsInDocument(long referenceId, long documentId);

        IEnumerable<Reference> GetReferences(long documentId);

        Reference GetReference(long referenceId);

        Task<Reference> CreateReference(Reference reference);

        Task<Reference> UpdateReference(long referenceId, ReferenceEdit referenceEdit);

        Task DeleteReference(long referenceId);
    }
}