namespace RefMan.Models.Repositories.FileSystem
{
    using RefMan.Models.FileSystem;
    using RefMan.Models.User;

    public interface IFolderRepository : IFileSystemRepository
    {
        Folder FindRootForUser(AppUser user);

        Folder FindFolderOrDefault(long id);
    }
}