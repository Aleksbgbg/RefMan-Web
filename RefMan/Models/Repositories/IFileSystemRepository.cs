namespace RefMan.Models.Repositories
{
    using System.Threading.Tasks;

    using RefMan.Models.FileSystem;

    public interface IFileSystemRepository
    {
        FileSystemEntryBase FindNodeOrDefault(long id);

        Task<FileSystemEntryBase> CreateNode(long parentId, long ownerId, string name);

        Task DeleteNode(FileSystemEntryBase node);
    }
}