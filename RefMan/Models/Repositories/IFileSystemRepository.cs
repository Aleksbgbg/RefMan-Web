namespace RefMan.Models.Repositories
{
    using System.Threading.Tasks;

    using RefMan.Models.FileSystem;
    using RefMan.Models.User;

    public interface IFileSystemRepository
    {
        Task GenerateRootFolderForUser(AppUser user);

        Folder FindRootForUser(AppUser user);

        Folder FindFolderOrDefault(long id);

        Task<Folder> CreateFolder(long parentId, long ownerId, string name);
    }
}