namespace RefMan.Models.Repositories.FileSystem
{
    using RefMan.Models.Referencing;

    public interface IFileRepository : IFileSystemRepository
    {
        Document GetDocumentForFileId(long id);
    }
}