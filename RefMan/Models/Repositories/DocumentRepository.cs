namespace RefMan.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RefMan.Models.Database;
    using RefMan.Models.Referencing;
    using RefMan.Utilities;

    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DocumentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool DocumentExists(long documentId)
        {
            return _appDbContext.Documents.Any(document => document.Id == documentId);
        }

        public bool UserOwnsDocument(long documentId, long ownerId)
        {
            return _appDbContext.Files.Single(file => file.DocumentId == documentId)
                                .OwnerId ==
                   ownerId;
        }

        public bool ReferenceExistsInDocument(long referenceId, long documentId)
        {
            return _appDbContext.References.Any(reference => reference.Id == referenceId && reference.DocumentId == documentId);
        }

        public IEnumerable<Reference> GetReferences(long documentId)
        {
            return _appDbContext.References.Where(reference => reference.DocumentId == documentId);
        }

        public Reference GetReference(long referenceId)
        {
            return _appDbContext.References.Single(reference => reference.Id == referenceId);
        }

        public async Task<Reference> CreateReference(Reference reference)
        {
            reference.Id = IdGenerator.GenerateId();

            _appDbContext.References.Add(reference);
            await _appDbContext.SaveChangesAsync();

            return reference;
        }

        public async Task<Reference> UpdateReference(long referenceId, ReferenceEdit referenceEdit)
        {
            Reference reference = GetReference(referenceId);

            reference.AccessDate = referenceEdit.AccessDate;
            reference.PublishYear = referenceEdit.PublishYear;
            reference.WebpageTitle = referenceEdit.WebpageTitle;
            reference.WebsiteName = referenceEdit.WebsiteName;

            _appDbContext.References.Update(reference);
            await _appDbContext.SaveChangesAsync();

            return reference;
        }

        public async Task DeleteReference(long referenceId)
        {
            _appDbContext.References.Remove(GetReference(referenceId));
            await _appDbContext.SaveChangesAsync();
        }
    }
}